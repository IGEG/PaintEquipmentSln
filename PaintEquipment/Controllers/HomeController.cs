using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;
using PaintEquipment.Models.ViewModels;

namespace PaintEquipment.Controllers
{
    public class HomeController : Controller
    {
        private IAppRepository repository;
        public int PageSize = 4;
        public HomeController(IAppRepository repo)
        { 
        repository = repo;
        }
       
        public ViewResult Index(string category, int numerPage = 1) => View(new ProductListViewModel {
            Products = repository.Products.Where(p=>category==null||p.Category==category)
            .OrderBy(p => p.Id).Skip((numerPage - 1) * PageSize).Take(PageSize),
            PageInfo = new PageInfo {
                CurrentPage = numerPage,
                QuantityProductOnPage = PageSize,
                TotalProduct = repository.Products.Count()
            }

        });

    }
}
