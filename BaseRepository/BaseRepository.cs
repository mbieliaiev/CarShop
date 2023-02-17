using Data.Base.Contract;
using Microsoft.EntityFrameworkCore;

namespace Data.Base.Implementation
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        private DbContext _context;
        public BaseRepository(DbContext context) {
            _context = context;
        }

        public async Task Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Bad data");
            }
            var collection = GetCollection();
            var carEntity = await GetEntity(id);

            collection.Remove(carEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var collection = GetCollection();
            return await collection.ToListAsync();
        }

        public async Task<TEntity> GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Bad data");
            }
            var result = await GetEntity(id);
            return result;
        }

        public async Task Insert(TEntity carEntity)
        {
            var collection = GetCollection();
            if (carEntity == null)
            {
                throw new ArgumentException("Bad data");
            }
            collection.Add(carEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity carEntity)
        {
            _context.Attach(carEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await GetEntity(carEntity.Id);
            }
        }

        private async Task<TEntity> GetEntity(int? id)
        {
            var collection = GetCollection();
            var entity = await collection.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Item with id {id} was not found");
            }
            return entity;
        }

        private DbSet<TEntity> GetCollection()
        {
            var collection = _context.Set<TEntity>();
            if (collection == null)
                throw new ArgumentException("Collection was not found");
            return collection;
        }
    }
}
