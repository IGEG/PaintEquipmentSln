using System.Linq;

namespace PaintEquipment.Models
{
    public class EFAppRequest : IAppRequest
    {
        AppDbContext appDbContext;
        public EFAppRequest(AppDbContext appDb)
        {
            appDbContext=appDb;
        }
        public IQueryable<Request> Requests => appDbContext.Requests;

        public void SaveRequest(Request request)
        {
            if(request.Id==0)
            {
                appDbContext.Add(request);

            }
            appDbContext.SaveChanges();

        }
        public void DeleteRequest(int Id)
        {
            Request req = appDbContext.Requests.Where(r => r.Id == Id).FirstOrDefault();
            if (req != null)
            { 
            appDbContext.Requests.Remove(req);
                appDbContext.SaveChanges();
            }

        }
    }
}
