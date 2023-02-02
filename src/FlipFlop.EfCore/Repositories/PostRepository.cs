using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;

namespace FlipFlop.EfCore.Repositories 
{
    public class PostRepository : BaseRepository<Post, long>
    {
        
        public PostRepository(FlipFlopContext db) : base(db)
        {

        }
    }
}