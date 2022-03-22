using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.DTO;
using _0317_Product_Repository.Repositories.Interface;
using _0317_Product_Repository.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace _0317_Product_Repository.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public void CreateProduct(ProductDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Count = request.Count
            };

            _repository.Create(product);
            _repository.Save();
        }

        public void DeleteProduct(int id)
        {
            var target = _repository.GetAll<Product>().FirstOrDefault(x => x.Id == id);

            _repository.DeleteById(target.Id);
            _repository.Save();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var productlist = _repository.GetAll<Product>().Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Tag = x.Price > 1000 ? "Expensive" : "Cheap",
                IsEmptyStock = x.Count == 0
            });

            return productlist;
        }

        public ProductDto GetProduct(int id)
        {
            var target = _repository.GetAll<Product>().FirstOrDefault(x => x.Id == id);

            return new ProductDto()
            {
                Id = target.Id,
                Name = target.Name,
                Price = target.Price,
                Count = target.Count,
                Tag = target.Price > 1000 ? "Expensive" : "Cheap",
                IsEmptyStock = target.Count == 0
            };
        }

        public void UpdateProduct(ProductDto request)
        {
            var product  = _repository.GetAll<Product>().FirstOrDefault(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Price = request.Price;
            product.Count = request.Count;

            _repository.Update(product);
            _repository.Save();
        }
    }
}
