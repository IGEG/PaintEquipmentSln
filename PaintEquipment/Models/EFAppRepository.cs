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
        public IQueryable<Product> products => _context.Products;
    }
}
