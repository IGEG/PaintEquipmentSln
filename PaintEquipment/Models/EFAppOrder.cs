using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace PaintEquipment.Models

{
    public class EFAppOrder: IAppOrder
    {
        private AppDbContext context;

        public EFAppOrder(AppDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
                            .Include(o => o.Rows)
                            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Rows.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}

