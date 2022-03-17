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
        public IEnumerable<ProductDto> GetAllProducts()
        {
            var ProductList = _productRepository.GetAll<Product>().Select(x => new ProductDto()
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

        public ProductDto GetProduct(int id)
        {
            var source = _productRepository.GetAll<Product>().First(x => x.Id == id);
            return new ProductDto()
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
                Count = source.Count,
                Tag = source.Price >= 200 ? "Expensive" : "Cheap",
                IsEmptyStock = source.Count == 0
            };
        }

        public void ProductUpdate(ProductDto request)
        {
            var target = _productRepository.GetAll<Product>().First(x => x.Id == request.Id);

            target.Name = request.Name;
            target.Price = request.Price;
            target.Count = request.Count;

            _productRepository.Update(target);
            _productRepository.Save();
        }

        public void DeleteProduct(int id)
        {
            var target = _productRepository.GetAll<Product>().First(x => x.Id == id);
            _productRepository.DeleteById(target.Id);
        }

        public void CreateProduct(Product request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Count = request.Count
            };

            _productRepository.Create(product);
            _productRepository.Save();
        }
    }
}
