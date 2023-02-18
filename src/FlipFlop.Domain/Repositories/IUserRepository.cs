using FlipFlop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User, string>
    {
        Task<bool> IsUserExist(string username, string password);
        Task<bool> IsUsernameTaken(string username);
        Task<User?> GetUserByUsername(string username);
        Task<List<User>> SearchUserByUsername(string username);
    }
}
