using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Repositories.Interface;
using System.Linq;

namespace _0317_Product_Repository.Repositories
{
    public class ProductRepository : DBRepository, IProductRepository
    {
        public ProductRepository(ProductsDBContext context) : base(context) { }

        public void DeleteById(int id)
        {
            var target = Context.Products.First(x => x.Id == id);
            Delete(target);

            Save();
        }
    }
}
