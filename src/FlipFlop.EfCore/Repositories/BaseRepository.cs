using System.Runtime.CompilerServices;
using FlipFlop.Domain.Repositories;
using FlipFlop.EfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipFlop.EfCore.Repositories
{
    public class BaseRepository<T, ID> : IBaseRepository<T, ID> where T : BaseModel<ID>
    {
        private readonly FlipFlopContext _db;
        public BaseRepository(FlipFlopContext db) 
        {
            _db = db;
        }
        public async Task<T?> GetById(ID id) 
        {
            return await _db.Set<T>()
                .FindAsync(id);
        }
        public async Task<List<T>> GetAll()
        {
            return await _db.Set<T>()
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
        public async Task<T?> Create(T entity)
        {
            var e = _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return e.Entity;
        }
        public async Task<T?> Update(ID id, T entity)
        {
            T? e = await this.GetById(id);
            if (e == null)
                return null;
            entity.Id = id;
            var updateResult = _db.Set<T>().Update(entity);
            return updateResult.Entity;
        }
        public async Task Delete(ID id)
        {
            T? e = await this.GetById(id);
            if (e == null)
                throw new Exception(); // todo make exception for this reason
            _db.Set<T>().Remove(e);
            await _db.SaveChangesAsync();
        }
    }
}