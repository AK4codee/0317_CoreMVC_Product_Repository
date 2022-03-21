using _0317_Product_Repository.Models.ViewModel.Product;
using _0317_Product_Repository.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        public IActionResult Detail(int id)
        {
            var source = _service.GetTheProduct(id);
            var product = new ProductDetailViewModel.productData()
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
                Count = source.Count,
                Tag = source.Tag
            };

            var res = new ProductDetailViewModel()
            {
                Title = product.Name,
                Product = product
            };

            return View(res);
        }
        
    }
}
