using System.Linq;
namespace PaintEquipment.Models
{
    public interface IAppProductRequest
    {
        IQueryable<ProductRequest> productRequests { get; }
        void SaveRequest(ProductRequest productRequest);
        void DeleteRequest(int Id);
    }
}
