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
        Task<List<Post>> GetUserPosts(string userId);
        Task<Post?> GetPostById(string id);
        Task<Post?> CreatePost(Post post);
        Task DeletePost(string id, string userId);
        Task<Post?> UpdatePost(string postId, Post updatedPost); // todo complete this
        Task<List<Post>> SearchPost(string q);
    }
}
