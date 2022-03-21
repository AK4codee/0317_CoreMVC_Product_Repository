using _0317_Product_Repository.Models.DTO;
using System.Collections.Generic;

namespace _0317_Product_Repository.Services.Interface
{
    public interface IShopService
    {
        public IEnumerable<ShopDto> GetAllShops();

        public IEnumerable<ShopDto> GetShopsWithNoProducts();

        public ShopDto GetTheShop(int id);

        public void CreateShop(ShopDto request);

        public void UpdateShop(ShopDto request);

        public void DeleteAllProductsInShop(int id);

        public void DeleteShop(int id);
    }
}
