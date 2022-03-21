namespace _0317_Product_Repository.Models.ViewModel.View
{
    public class ProductDetailViewModel
    {
        public string Title { get; set; } 
        public ProductData Product { get; set; }
        public class ProductData
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
            public string Tag { get; set; }
            public bool IsEmptyStock { get; set; }
        }
    }
}
