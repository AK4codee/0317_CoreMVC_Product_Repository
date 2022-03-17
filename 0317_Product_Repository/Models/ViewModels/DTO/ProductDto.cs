namespace _0317_Product_Repository.Models.ViewModels.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Tag { get; set; }
        public bool IsEmptyStock { get; set; }
    }
}
