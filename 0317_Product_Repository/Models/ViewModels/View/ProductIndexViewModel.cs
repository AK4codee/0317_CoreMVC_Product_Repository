using _0317_Product_Repository.Models.ViewModels.DTO;
using System.Collections.Generic;

namespace _0317_Product_Repository.Models.ViewModels.View
{
    public class ProductIndexViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ProductData> ProductList { get; set; }

        // 定義這個 view 專用的 model
        public class ProductData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
