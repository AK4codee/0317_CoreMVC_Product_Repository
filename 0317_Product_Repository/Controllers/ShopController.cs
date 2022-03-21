using _0317_Product_Repository.Models.ViewModel;
using _0317_Product_Repository.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _0317_Product_Repository.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _service;
        public ShopController(IShopService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var shoplist = _service.GetAllShops().Select(x => new ShopIndexViewModel.ShopData()
            {
                Id = x.ShopId,
                Name = x.ShopName,
                Owner = x.Owner,
                ProductCount = x.Products.Count
            });

            var result = new ShopIndexViewModel()
            {
                Title = "商店列表",
                ShopList = shoplist
            };

            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var source = _service.GetTheShop(id);
            var productlist = _service.GetShopProduct(id).Select(x => new ShopDetailViewModel.ProductData()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            });

            var shop = new ShopDetailViewModel.ShopData()
            {
                ShopId = source.ShopId,
                ShopName = source.ShopName,
                Owner = source.Owner,
            };

            var result = new ShopDetailViewModel()
            {
                Title = source.ShopName,
                Shop = shop,
                ProductList = productlist
            };

            return View(result);
        }
    }
}
