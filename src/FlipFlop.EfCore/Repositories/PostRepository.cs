using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipFlop.EfCore.Repositories 
{
    public class PostRepository : BaseRepository<Post, long>, IPostRepository
    {
        
        public PostRepository(FlipFlopContext db) : base(db)
        {
            
        }

        public async Task<List<Post>> GetUserPosts(long UserId) 
        {
            return await _db.posts.Where(x => x.AuthorId == UserId).ToListAsync();
        }
    }
}