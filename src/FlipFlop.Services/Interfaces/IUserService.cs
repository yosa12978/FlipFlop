using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUser(string username, string password);
        Task<User?> GetUserById(string id);
        Task<List<User>> SearchByUsername(string username);
        Task<User?> CreateUser(string Username, string Password);
        Task DeleteUser(string Username, string Password);
    }
}
