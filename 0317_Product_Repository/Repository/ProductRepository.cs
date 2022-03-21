using _0317_Product_Repository.Models;
using _0317_Product_Repository.Repository.Interface;
using System.Linq;

namespace _0317_Product_Repository.Repository
{
    public class ProductRepository : DBRepository, IProductRepository
    {
        public ProductRepository(ProductsDBContext context) : base(context)
        {
        }

        public void DeleteById(int id)
        {
            var target = Context.Products.FirstOrDefault(x => x.Id == id);
            Delete(target);
            Save();
        }
    }
}
