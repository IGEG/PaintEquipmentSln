using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PaintEquipment.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public IEnumerable<Category> categories { get; set; }

    }
}
