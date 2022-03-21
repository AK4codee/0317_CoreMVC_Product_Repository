using System;
using System.Collections.Generic;

#nullable disable

namespace _0317_Product_Repository.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Products = new HashSet<Product>();
        }

        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Owner { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
