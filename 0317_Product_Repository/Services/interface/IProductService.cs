using _0317_Product_Repository.Models.DBEntity;
using _0317_Product_Repository.Models.ViewModels.DTO;
using System.Collections.Generic;

namespace _0317_Product_Repository.Services.Interface
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetAllProducts();
        public ProductDto GetProduct(int id);
        public void ProductUpdate(ProductDto request);

        public void DeleteProduct(int id);

        public void CreateProduct(Product request);
    }
}

