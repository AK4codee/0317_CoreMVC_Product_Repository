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
                Id = x.Id,
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

        public IActionResult Detail(int id)
        {
            var productDto = _service.GetProduct(id);
            var productDetail = new ProductDetailViewModel.ProductData
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Count = productDto.Count,
                Tag = productDto.Tag,
                IsEmptyStock = productDto.IsEmptyStock
            };

            var res = new ProductDetailViewModel
            {
                Title = $"{productDetail.Name}的詳細資訊",
                Product = productDetail
            };

            return View(res);
        }
    }
}
