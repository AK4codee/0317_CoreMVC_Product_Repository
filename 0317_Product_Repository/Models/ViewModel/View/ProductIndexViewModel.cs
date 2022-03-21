using System.Collections.Generic;

namespace _0317_Product_Repository.Models.ViewModel.View
{
    public class ProductIndexViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<ProductData> productlist;
        public class ProductData
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }
    }
}
