using ECommerce.Entities.Models;

namespace ECommerce.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product>? Products { get; set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int PageCount { get; internal set; }
        public int CurrentPage { get; internal set; }
        public bool IsAtoZ { get; internal set; } = true;
        public bool IsHighToLow { get; internal set; } = false;
        public bool Which { get; internal set; } = true;
    }
}