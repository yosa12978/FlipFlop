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
        public async Task<User?> CreateUser(string Username, string Password)
        {
            string salt = CryptoHelper.NewSalt(32); 
            User usr = new User{
                Username = Username,
                Password = CryptoHelper.CreateMD5(Password + salt),
                Salt = salt,
            };
            User? res = await _userRepository.Create(usr);
            return res;
        }

        public async Task DeleteUser(string Username, string Password)
        {
            User? usr = await _userRepository.GetByUsernameAndPassword(Username, Password);
            if (usr != null)
            {
                await _userRepository.Delete(usr.Id);
                return;
            }
            throw new Exception(); // todo make a forbidden exception
        }

        public async Task<User?> GetUser(string username, string password)
        {
            return await _userRepository.GetByUsernameAndPassword(username, CryptoHelper.CreateMD5(password));
        }

        public async Task<User?> GetUserById(long id)
        {
            return await _userRepository.GetById(id);
        }

    }
}