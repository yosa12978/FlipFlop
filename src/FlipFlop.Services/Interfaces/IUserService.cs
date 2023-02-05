using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUser(string username, string password);
        Task<User?> GetUserById(long id);
        Task<User?> CreateUser(string Username, string Password);
        Task DeleteUser(string Username, string Password);
    }
}
