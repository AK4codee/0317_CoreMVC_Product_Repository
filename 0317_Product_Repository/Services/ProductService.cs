using _0317_Product_Repository.Models;
using _0317_Product_Repository.Models.DTO;
using _0317_Product_Repository.Repository.Interface;
using _0317_Product_Repository.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace _0317_Product_Repository.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _context;
        public ProductService(IProductRepository context)
        {
            _context = context;
        }
        public void CreateProduct(ProductDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Count = request.Count,
                ShopId = request.ShopId
            };

            _context.Create(product);
            _context.Save();
        }

        public void DeleteProduct(int id)
        {
            var target = _context.GetAll<Product>().First(x => x.Id == id);

            _context.DeleteById(target.Id);
            _context.Save();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var productlist = _context.GetAll<Product>().Select(x => new ProductDto { 
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Tag = x.Price > 1000 ? "Expensice" : "Cheap",
                ShopId=x.ShopId
            });

            return productlist;
        }

        public ProductDto GetTheProduct(int id)
        {
            var target = _context.GetAll<Product>().First(x => x.Id == id);

            return new ProductDto
            {
                Id = target.Id,
                Name = target.Name,
                Price = target.Price,
                Tag = target.Price > 1000 ? "Expensice" : "Cheap",
                ShopId = target.ShopId
            };
        }

        public void UpdateProduct(ProductDto request)
        {
            var source = _context.GetAll<Product>().First(x => x.Id == request.Id);

            source.Name = source.Name;
            source.Price = source.Price;
            source.Count = source.Count;

            _context.Update(source);
            _context.Save();
        }
    }
}
