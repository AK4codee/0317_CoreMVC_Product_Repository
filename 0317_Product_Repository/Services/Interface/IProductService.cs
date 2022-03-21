using _0317_Product_Repository.Models.ViewModel.DTO;
using System.Collections;
using System.Collections.Generic;

namespace _0317_Product_Repository.Services.Interface
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetAllProducts();
        public ProductDto GetProduct(int id);
        public void ProductUpdate(ProductDto request);
        public void ProductDelete(int id);
        public void CreateProduct(ProductDto request);
    }
}
