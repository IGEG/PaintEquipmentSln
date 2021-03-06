using System.Linq;
namespace PaintEquipment.Models
{
    public interface IAppRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);

        Product DeleteProduct(int ID);
    }
}
