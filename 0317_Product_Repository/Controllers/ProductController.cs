using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.ViewModels.DTO;
using _0317_Product_Repository.Models.ViewModels.View;
using _0317_Product_Repository.Services;
using _0317_Product_Repository.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _0317_Product_Repository.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var productList = _productService.GetAllProducts().Select(x => new ProductIndexViewModel.ProductData
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
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
            var productDTO = _productService.GetProduct(id);

            var product = new ProductDetailViewModel.ProductData
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Price = productDTO.Price,
                Count = productDTO.Count,
                Tag = productDTO.Price >= 200 ? "Expensive" : "Cheap",
                IsEmptyStock = productDTO.Count == 0
            };

            var res = new ProductDetailViewModel()
            {
                Product = product
            };

            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product request)
        {
            _productService.CreateProduct(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var theProduct = _productService.GetProduct(id);
            var product = new ProductEditViewModel.ProductData
            {
                Id = theProduct.Id,
                Name = theProduct.Name,
                Price = theProduct.Price,
                Count = theProduct.Count
            };
            var res = new ProductEditViewModel()
            {
                Product = product
            };
            return View("ProductEdit",res);
        }

        [HttpPost]
        public IActionResult Edit(ProductDetailViewModel.ProductData request)
        {
            var productDTO = new ProductDto
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Count = request.Count
            };
            _productService.ProductUpdate(productDTO);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
