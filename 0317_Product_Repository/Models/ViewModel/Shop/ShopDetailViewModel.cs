using System.Collections.Generic;

namespace _0317_Product_Repository.Models.ViewModel
{
    public class ShopDetailViewModel
    {
        public string Title { get; set; }
        public ShopData Shop { get; set; }
        public IEnumerable<ProductData> ProductList { get; set; }
        public class ShopData
        {
            public int ShopId { get; set; }
            public string ShopName { get; set; }
            public string Owner { get; set; }

        }
        public class ProductData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
