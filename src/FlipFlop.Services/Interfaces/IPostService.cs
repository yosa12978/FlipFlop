using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();
        Task<List<Post>> GetUserPosts(long userId);
        Task<Post?> GetPostById(long id);
        Task<Post?> CreatePost(Post post);
        Task DeletePost(long id, long userId);
        Task<Post?> UpdatePost(long postId, Post updatedPost); // todo complete this
    }
}
