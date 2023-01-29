using FlipFlop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.Domain.Repositories
{
    public interface IBaseRepository<T, ID> where T : BaseModel<ID>
    {
        Task<T> GetById(ID id);
        Task<List<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(ID id, T entity);
        Task Delete(ID id);
    }
}
