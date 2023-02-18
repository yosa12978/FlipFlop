using FlipFlop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Repositories
{
    public interface IPostRepository : IBaseRepository<Post, string>
    {
        Task<List<Post>> GetUserPosts(string UserId);
        Task<List<Post>> SearchPost(string q);
    }
}
