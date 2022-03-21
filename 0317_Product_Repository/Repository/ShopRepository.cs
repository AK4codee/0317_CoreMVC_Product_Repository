using _0317_Product_Repository.Models;
using _0317_Product_Repository.Repository.Interface;
using System.Linq;

namespace _0317_Product_Repository.Repository
{
    public class ShopRepository : DBRepository, IShopRepository
    {
        public ShopRepository(ProductsDBContext context) : base(context)
        {
        }

        public void DeleteById(int id)
        {
            var target = Context.Shops.FirstOrDefault(x => x.ShopId == id);
            Delete(target);

            Save();
        }
    }
}
