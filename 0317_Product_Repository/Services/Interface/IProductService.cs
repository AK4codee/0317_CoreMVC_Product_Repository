using _0317_Product_Repository.Models.DTO;
using System.Collections.Generic;

namespace _0317_Product_Repository.Services.Interface
{
    public interface IProductService
    {
        public void CreateProduct(ProductDto request);
        public IEnumerable<ProductDto> GetAllProducts();
        public ProductDto GetProduct(int id);
        public void UpdateProduct(ProductDto request);
        public void DeleteProduct(int id);
    }
}
