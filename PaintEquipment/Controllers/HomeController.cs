using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;

namespace PaintEquipment.Controllers
{
    public class HomeController : Controller
    {
        IAppRepository repository;
        public HomeController(IAppRepository repo)
        { 
        repository = repo;
        }
        public IActionResult Index() => View(repository.Products);

    }
}
