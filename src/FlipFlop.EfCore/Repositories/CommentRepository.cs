using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;

namespace FlipFlop.EfCore.Repositories 
{
    public class CommentRepository : BaseRepository<Comment, long>
    {
        
        public CommentRepository(FlipFlopContext db) : base(db)
        {

        }
    }
}