using FlipFlop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        Task<bool> IsUserExist(string username, string password);
        Task<bool> IsUsernameTaken(string username);
        Task<User?> GetByUsernameAndPassword(string username, string passwordHash);
    }
}
