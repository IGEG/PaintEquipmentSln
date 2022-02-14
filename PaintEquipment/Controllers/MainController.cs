using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;

namespace PaintEquipment.Controllers
{
    public class MainController : Controller
    {

        IAppRequest request;
        public MainController(IAppRequest req)
        {
            request = req;
        }
        public ViewResult Index() => View();

        [HttpPost]
        public IActionResult SaveRequst(Request req)
        {
            if (ModelState.IsValid)
            {
                request.SaveRequest(req);
                return RedirectToAction(nameof(CompletedRequest));
            }
            else
            {
                return View("Index");
            }
        }
        public ViewResult CompletedRequest() => View();
    }
}
