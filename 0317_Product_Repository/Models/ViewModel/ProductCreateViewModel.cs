namespace _0317_Product_Repository.Models.ViewModel
{
    public class ProductCreateViewModel
    {
        public ProductData product { get; set; }

        public class ProductData
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }
    }
}
