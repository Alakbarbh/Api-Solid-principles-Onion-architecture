using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;


namespace Repository.Repositories.Interfaces
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            if(entity == null) { throw new ArgumentNullException(nameof(entity)); }
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if(entity is null) { throw new ArgumentNullException(nameof(entity)); }
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if(id is null) { throw new ArgumentNullException(); }
            T entity = await _entities.FindAsync(id);
            if(entity is null) { throw new NullReferenceException(nameof(entity)); }
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
