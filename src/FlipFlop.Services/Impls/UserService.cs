using System.Data.Common;
using FlipFlop.Helpers.Exceptions;
using FlipFlop.Services.Interfaces;

namespace FlipFlop.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<List<User>> SearchByUsername(string username)
        {
            return await _userRepository.SearchUserByUsername(username);
        }

        public async Task<User?> GetUser(string username, string password)
        {
            User? usr = await _userRepository.GetUserByUsername(username);
            if (usr == null || usr.Password != CryptoHelper.CreateMD5(password + usr.Salt))
                return null;//throw new NotFoundException("user not found");
            return usr;
        }

        public async Task<User?> CreateUser(string Username, string Password)
        {
            if (await _userRepository.IsUsernameTaken(Username))
            {
                throw new Exception("username is already taken");
            }
            string salt = CryptoHelper.NewSalt(16); 
            User usr = new User{
                Id = Guid.NewGuid().ToString(),
                Username = Username,
                Password = CryptoHelper.CreateMD5(Password + salt),
                Salt = salt,
                Role = Roles.USER,
            };
            User? res = await _userRepository.Create(usr);
            return res;
        }

        public async Task DeleteUser(string Username, string Password)
        {
            User? usr = await this.GetUser(Username, Password);
            if (usr != null)
            {
                await _userRepository.Delete(usr.Id);
                return;
            }
            throw new ForbiddenException("you are not able to do this");
        }
    }
}