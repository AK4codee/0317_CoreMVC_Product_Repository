using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.ViewModels.DTO;
using _0317_Product_Repository.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace _0317_Product_Repository.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // 業務邏輯
        // 原本寫在 Controller
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var ProductList = _productRepository.GetAll<Product>().Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Tag = x.Price >= 200 ? "Expensive" : "Cheap",
                IsEmptyStock = x.Count == 0
            });

            return ProductList;
        }

        public ProductViewModel GetProduct(int id)
        {
            var source = _productRepository.GetAll<Product>().First(x => x.Id == id);
            return new ProductViewModel()
            {
                Name = source.Name,
                Price = source.Price,
                Count = source.Count,
                Tag = source.Price >= 200 ? "Expensive" : "Cheap",
                IsEmptyStock = source.Count == 0
            };
        }
    }
}
