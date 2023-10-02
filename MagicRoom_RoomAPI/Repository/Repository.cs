using MagicHouse_HouseAPI.Data;
using MagicHouse_HouseAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicT_TAPI.Repository
{
    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            
            _dbSet = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> T = _dbSet;
            if (!tracked)
            {
                T = T.AsNoTracking();
            }
            if (filter != null)
            {
                T = T.Where(filter);
            }
            if(includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    T = T.Include(includeProp);
                }
            }
            return await T.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> T = _dbSet;
            if (filter != null)
            {
                T = T.Where(filter);
            }

			if (includeProperties != null)
			{
				foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					T = T.Include(includeProp);
				}
			}
			return await T.ToListAsync();

        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
