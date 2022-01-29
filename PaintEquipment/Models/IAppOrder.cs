using System.Linq;

namespace PaintEquipment.Models
{
    public interface IAppOrder
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
