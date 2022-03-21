using _0317_Product_Repository.Models.DTO;
using System.Collections.Generic;

namespace _0317_Product_Repository.Services.Interface
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetAllProducts();
        public ProductDto GetTheProduct(int id);

        public void CreateProduct(ProductDto request);

        public void UpdateProduct(ProductDto request);

        public void DeleteProduct(int id);
    }
}
