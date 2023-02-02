using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;

namespace FlipFlop.EfCore.Repositories 
{
    public class UserRepository : BaseRepository<User, long>
    {
        
        public UserRepository(FlipFlopContext db) : base(db)
        {

        }
    }
}