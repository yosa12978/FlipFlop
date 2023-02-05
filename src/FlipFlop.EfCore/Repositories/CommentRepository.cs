using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipFlop.EfCore.Repositories 
{
    public class CommentRepository : BaseRepository<Comment, long>, ICommentRepository
    {
        
        public CommentRepository(FlipFlopContext db) : base(db)
        {

        }

        public async Task<List<Comment>> GetPostComments(long PostId)
        {
            return await _db.comments.Where(c => c.PostId == PostId).ToListAsync();
        }
    }
}