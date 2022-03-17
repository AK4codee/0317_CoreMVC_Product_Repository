using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.ViewModels.DTO;
using _0317_Product_Repository.Models.ViewModels.View;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _0317_Product_Repository.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsDBContext _DBContext;

        public ProductController(ProductsDBContext productsDBContext)
        {
            _DBContext = productsDBContext;
        }
        public IActionResult Index()
        {
            var productList = _DBContext.Products.Select(x => new ProductViewModel()
            {
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Tag = x.Price >= 200 ? "Expensive" : "Cheap",
                IsEmptyStock = x.Count == 0
            });

            var res = new ProductIndexViewModel
            {
                Title = "產品目錄",
                ProductList = productList
            };

            return View(res);
        }

        public IActionResult ProductDetail(int id)
        {
            var sourceProduct = _DBContext.Products.First(x => x.Id == id);

            var theProduct = new ProductViewModel()
            {
                Name = sourceProduct.Name,
                Price = sourceProduct.Price,
                Count = sourceProduct.Count,
                Tag = sourceProduct.Price >= 200 ? "Expensive" : "Cheap",
                IsEmptyStock = sourceProduct.Count == 0
            };

            var res = new ProductDetailViewModel()
            {
                Product = theProduct
            };

            return View(res);
        }
    }
}
