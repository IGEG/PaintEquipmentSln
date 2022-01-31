using System.Linq;
namespace PaintEquipment.Models
{
    public class EFAppRepository : IAppRepository
    {
        private AppDbContext _context;
        public EFAppRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IQueryable<Product> Products => _context.Products;

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
                    editproduct.Description = product.Description;
                    editproduct.Category = product.Category;
                    editproduct.Price = product.Price;
                }
            }
            _context.SaveChanges();
        }
    }
}
