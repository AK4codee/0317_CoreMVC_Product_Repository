using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.ViewModels.DTO;
using _0317_Product_Repository.Models.ViewModels.View;
using _0317_Product_Repository.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _0317_Product_Repository.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var productList = _productService.GetAllProducts();

            var res = new ProductIndexViewModel
            {
                Title = "產品目錄",
                ProductList = productList
            };

            return View(res);
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _productService.GetProduct(id);

            var res = new ProductDetailViewModel()
            {
                Product = product
            };

            return View(res);
        }
    }
}
