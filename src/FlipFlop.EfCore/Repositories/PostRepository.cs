using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipFlop.EfCore.Repositories 
{
    public class PostRepository : BaseRepository<Post, string>, IPostRepository
    {
        
        public PostRepository(FlipFlopContext db) : base(db)
        {
            
        }

        public async Task<List<Post>> GetUserPosts(string UserId) 
        {
            return await _db.posts.Where(x => x.AuthorId == UserId).ToListAsync();
        }
        
        public async Task<List<Post>> SearchPost(string q)
        {
            return await _db.posts
                .Where(x => x.Title.Contains(q) || x.Body.Contains(q))
                .OrderByDescending(x => x.PubDate)
                .ToListAsync();
        }

        public override IQueryable<Post> GetAll() 
        {
            return _db.posts
                .OrderByDescending(x => x.PubDate);
        }
    }
}