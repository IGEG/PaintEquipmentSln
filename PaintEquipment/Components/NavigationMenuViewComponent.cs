using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;
namespace PaintEquipment.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        IAppRepository appRepository;
        public NavigationMenuViewComponent(IAppRepository app)
        {
            appRepository = app;
        }
        public IViewComponentResult Invoke() {
            return View(appRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
            }

    }
}
