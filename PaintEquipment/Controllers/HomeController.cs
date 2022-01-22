using Microsoft.AspNetCore.Mvc;

namespace PaintEquipment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

    }
}
