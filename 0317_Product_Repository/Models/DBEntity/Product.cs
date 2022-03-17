using System;
using System.Collections.Generic;

#nullable disable

namespace _0317_Product_Repository.Models.DBEntity
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
