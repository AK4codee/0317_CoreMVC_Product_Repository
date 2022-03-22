namespace _0317_Product_Repository.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Tag { get; set; }
        public bool IdEmptyStock { get; set; }
    }
}
