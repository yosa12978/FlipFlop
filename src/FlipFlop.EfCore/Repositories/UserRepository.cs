using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;
using FlipFlop.Helpers;

namespace FlipFlop.EfCore.Repositories 
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        
        public UserRepository(FlipFlopContext db) : base(db)
        {

        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await Task.Run(() => _db.users.Any(x => x.Username == username));
        }

        public async Task<bool> IsUserExist(string username, string password)
        {
            return await Task.Run(() => _db.users.Any(x => x.Username == username && 
                                                           x.Password == CryptoHelper.CreateMD5(password)));
        }
    }
}