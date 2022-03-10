using System.Linq;
namespace PaintEquipment.Models
{
    public class EFAppProductRequest:IAppProductRequest
    {
        AppDbContext appDbContext;
        public EFAppProductRequest(AppDbContext appDb)
        {
            appDbContext = appDb;
        }

        public IQueryable<ProductRequest> productRequests => appDbContext.ProductRequests;

        public void SaveRequest(ProductRequest productRequest)
        {
            if (productRequest.Id == 0)
            {
                appDbContext.Add(productRequest);

            }
            appDbContext.SaveChanges();

        }
        public void DeleteRequest(int Id)
        {
            ProductRequest req = appDbContext.ProductRequests.Where(r => r.Id == Id).FirstOrDefault();
            if (req != null)
            {
                appDbContext.ProductRequests.Remove(req);
                appDbContext.SaveChanges();
            }

        }
    }
}
