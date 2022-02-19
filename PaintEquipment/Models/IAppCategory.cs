using System.Collections.Generic;
using System.Linq;

namespace PaintEquipment.Models
{
    public interface IAppCategory
    {
        IEnumerable<Category> categories { get; }
        void SaveCategory(Category category);
        Category DeleteCategory(int Id);
        void EditCategory(Category category);
        
    }
}
