using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaintEquipment.Models;
namespace PaintEquipment.Models
{
    public class EFAppRepository : IAppRepository
    {
        private AppDbContext _context;
        public EFAppRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IQueryable<Product> Products => _context.Products.Include(c=>c.Category);

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product editproduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (editproduct != null)
                {
                    editproduct.Name = product.Name;
                    editproduct.SmallDescription = product.SmallDescription;
                    editproduct.BigDescription = product.BigDescription;
                    editproduct.MaxPressure = product.MaxPressure;
                    editproduct.MaxVolume = product.MaxVolume;
                    editproduct.MaxWeight = product.MaxWeight;
                    editproduct.Kit = product.Kit;
                    editproduct.CategoryId = product.CategoryId;
                    editproduct.URLadress = product.URLadress;
                }
            }
            _context.SaveChanges();
        }

        public Product DeleteProduct(int ID)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == ID);
            if (product != null)
            {
               
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }
       
    }
}
