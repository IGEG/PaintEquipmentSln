using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;

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

        public ViewResult Edit(int ID) => View(repository.Products.FirstOrDefault(p => p.Id == ID));

        [HttpPost]

        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} успешно сохранен!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}
