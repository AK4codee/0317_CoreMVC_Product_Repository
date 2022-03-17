﻿using _0317_Product_Repository.Models.ViewModels.DTO;

namespace _0317_Product_Repository.Models.ViewModels.View
{
    public class ProductEditViewModel
    {
        public ProductData Product { get; set; }

        public class ProductData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }
    }
}
