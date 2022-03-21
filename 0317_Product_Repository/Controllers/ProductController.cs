using _0317_Product_Repository.Models.ViewModel.View;
using _0317_Product_Repository.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _0317_Product_Repository.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var productlist = _service.GetAllProducts().Select(x => new ProductIndexViewModel.ProductData
            {
                Name = x.Name,
                Price = x.Price,
                Count = x.Count
            });
            var res = new ProductIndexViewModel
            {
                Title = "產品目錄",
                Description = "產品目錄",
                productlist = productlist
            };

            return View(res);
        }
    }
}
