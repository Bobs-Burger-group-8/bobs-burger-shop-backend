
using bobs_burger_api.Data;
using Microsoft.EntityFrameworkCore;

namespace bobs_burger_api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BobsBurgerContext _db;
        private DbSet<T> _dbSet;
        public Repository(BobsBurgerContext db) 
        { 
            _db = db;
            _dbSet = db.Set<T>();
        }
        public async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
