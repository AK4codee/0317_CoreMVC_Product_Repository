using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _0317_Product_Repository.Repositories
{
    public class DBRepository : IDBRepository
    {
        private readonly ProductsDBContext _context;

        public DBRepository(ProductsDBContext context)
        {
            _context = context;
        }

        public ProductsDBContext Context { get { return _context; } }

        public void Create<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete<T>(T entity) where T : class
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

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
