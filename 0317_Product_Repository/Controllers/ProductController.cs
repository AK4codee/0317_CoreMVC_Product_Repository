using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.DTO;
using _0317_Product_Repository.Models.ViewModel;
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
            var productlist = _service.GetAllProducts().Select(x => new ProductIndexViewModel.ProductData()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            });

            var result = new ProductIndexViewModel()
            {
                Title = "所有商品列表",
                productlist = productlist
            };

            return View(result);
        }
        public IActionResult Detail(int id)
        {
            var target = _service.GetProduct(id);
            var product = new ProductDetailViewModel.ProductData()
            {
                Id = target.Id,
                Name = target.Name,
                Price = target.Price,
                Count = target.Count,
                Tag = target.Tag,
                IsEmptyStock = target.IsEmptyStock
            };

            var result = new ProductDetailViewModel()
            {
                Title = $"{product.Name}的商品資訊",
                product = product
            };


            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto request)
        {
            _service.CreateProduct(request);

            return RedirectToAction(nameof(Index));
        }
    }
}
