using System.Collections.Generic;

namespace _0317_Product_Repository.Models.ViewModel
{
    public class ShopIndexViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ShopData> ShopList { get; set; }

        public class ShopData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Owner { get; set; }
            public int ProductCount { get; set; }
        }
    }
}
