using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;

namespace PaintEquipment.Controllers
{
    public class AdminController:Controller
    {
        IAppRepository repository;
        public AdminController(IAppRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Products);
    }
}
