using _0317_Product_Repository.Models;
using _0317_Product_Repository.Models.DTO;
using _0317_Product_Repository.Repository.Interface;
using _0317_Product_Repository.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace _0317_Product_Repository.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _context;

        public ShopService(IShopRepository context)
        {
            _context = context;
        }
        public void CreateShop(ShopDto request)
        {
            var source = new Shop
            {
                ShopName = request.ShopName,
                Owner = request.Owner,
            };

            _context.Create(source);
            _context.Save();

        }

        public void DeleteShop(int id)
        {
            var target = _context.GetAll<Shop>().First(x => x.ShopId == id);

            _context.DeleteById(target.ShopId);
            _context.Save();
        }

        public IEnumerable<ShopDto> GetAllShops()
        {
            var shoplist = _context.GetAll<Shop>().Select(x => new ShopDto()
            {
                ShopId = x.ShopId,
                ShopName = x.ShopName,
                Owner = x.Owner,
                IsNoProduct = x.Products.Count() == 0,
                Products = x.Products
            });

            return shoplist;
        }

        public IEnumerable<ProductDto> GetShopProduct(int id)
        {
            
            var shop = _context.GetAll<Shop>().First(x => x.ShopId == id);
            var products = _context.GetAll<Product>().Where(x => x.ShopId == id).Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Tag = x.Price > 1000 ? "Expensice" : "Cheap",
                ShopId = shop.ShopId
            });

            return products;
        }

        public ShopDto GetTheShop(int id)
        {
            var shop = _context.GetAll<Shop>().First(x => x.ShopId == id);

            return new ShopDto
            {
                ShopId = shop.ShopId,
                ShopName = shop.ShopName,
                Owner = shop.Owner,
                IsNoProduct = shop.Products.Count() == 0,
                Products = shop.Products
            };
        }

        public void UpdateShop(ShopDto request)
        {
            var shop = _context.GetAll<Shop>().First(x => x.ShopId == request.ShopId);

            shop.ShopName = request.ShopName;
            shop.Owner = request.Owner;

            _context.Update(shop);
            _context.Save();
        }
    }
}
