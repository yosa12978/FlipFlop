using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipFlop.EfCore.Repositories 
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
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
            return await Task.Run(() => _db.users.Any(x => x.Username == username &&  // ? am i need this method
                                                           x.Password == password)); // todo rewrite this method
                                                           
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _db.users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<User>> SearchUserByUsername(string username)
        {
            return await _db.users.Where(x => x.Username.Contains(username)).ToListAsync();
        }
    }
}