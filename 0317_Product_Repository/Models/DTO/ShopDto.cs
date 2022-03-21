using System.Collections.Generic;

namespace _0317_Product_Repository.Models.DTO
{
    public class ShopDto
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Owner { get; set; }
        public bool IsNoProduct { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
