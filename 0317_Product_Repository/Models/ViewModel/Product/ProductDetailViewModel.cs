namespace _0317_Product_Repository.Models.ViewModel.Product
{
    public class ProductDetailViewModel
    {
        public string Title { get; set; }
        public productData Product { get; set; }

        public class productData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
            public string Tag { get; set; }
        }
    }
}
