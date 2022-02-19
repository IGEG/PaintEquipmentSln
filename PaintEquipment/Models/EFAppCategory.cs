using System.Collections.Generic;
using System.Linq;

namespace PaintEquipment.Models
{
    public class EFAppCategory : IAppCategory
    {
        AppDbContext context { get; }
        public EFAppCategory( AppDbContext app)
        {
            context = app;
        }
        public IEnumerable<Category> categories => context.Categories;

        public Category DeleteCategory(int ID)
        {
            Category cat = context.Categories.FirstOrDefault(c => c.Id == ID);
            if (cat != null)
            {
                context.Categories.Remove(cat);
                context.SaveChanges();
            }
            return cat;

        }

        public void EditCategory(Category category)
        {
            Category cat = context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (cat != null)
            {
                cat.Name = category.Name;
                cat.Desc = category.Desc;
            }
            else {
                SaveCategory(category);
            }
            context.SaveChanges();

        }
        

        public void SaveCategory(Category category)
        {
            if (category != null)
            {
                context.Categories.Add(category);
            }
                context.SaveChanges();
            
        }
    }
}
