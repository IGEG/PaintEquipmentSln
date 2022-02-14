using System.Linq;

namespace PaintEquipment.Models
{
    public interface IAppRequest
    {
        IQueryable<Request> Requests { get; }
        void SaveRequest(Request request);
        void DeleteRequest(int Id);

    }
}
