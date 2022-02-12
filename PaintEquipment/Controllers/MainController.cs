using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;

namespace PaintEquipment.Controllers
{
    public class MainController:Controller
    {
        AppDbContext AppDbContext;

        public MainController(AppDbContext appDb)
        {
            AppDbContext = appDb;

        }
        public ViewResult Index() =>  View();
    }
}
