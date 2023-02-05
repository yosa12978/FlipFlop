using FlipFlop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Repositories
{
    public interface IPostRepository : IBaseRepository<Post, long>
    {
        Task<List<Post>> GetUserPosts(long UserId);
    }
}
