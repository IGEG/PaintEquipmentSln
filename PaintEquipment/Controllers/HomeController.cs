using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;
using PaintEquipment.Models.ViewModels;

namespace PaintEquipment.Controllers
{
    public class HomeController : Controller
    {
        IAppRepository repository;
        public HomeController(IAppRepository repo)
        { 
        repository = repo;
        }
        public int PageSize = 4;
        public ViewResult Index(int numerPage = 1) => View(new ProductListViewModel {
            Products = repository.Products.OrderBy(p => p.Id).Skip((numerPage - 1) * PageSize).Take(PageSize),
            PageInfo = new PageInfo {
                CurrentPage = numerPage,
                QuantityProductOnPage = PageSize,
                TotalProduct = repository.Products.Count()
            }

        });

    }
}
