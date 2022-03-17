using _0317_Product_Repository.Models.DBEntity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _0317_Product_Repository.Repositories
{
    public class DBRepository
    {
        private readonly ProductsDBContext _context;

        public DBRepository(ProductsDBContext context)
        {
            _context = context;
        }

        public ProductsDBContext Context { get { return _context; } }

        public virtual void Create<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
