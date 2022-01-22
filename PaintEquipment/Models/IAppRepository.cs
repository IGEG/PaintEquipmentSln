using System.Linq;
namespace PaintEquipment.Models
{
    public interface IAppRepository
    {
        IQueryable<Product> Products { get; }
    }
}
