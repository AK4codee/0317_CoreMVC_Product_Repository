using _0317_Product_Repository.Models.ViewModels.DTO;
using System.Collections.Generic;

namespace _0317_Product_Repository.Models.ViewModels.View
{
    public class ProductIndexViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }
    }
}
