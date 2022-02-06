using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace PaintEquipment.Controllers
{
    [Authorize]
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
        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]

        public IActionResult Delete(int Id)
        {
            Product product = repository.DeleteProduct(Id);
            if (product != null)
            {
                TempData["message"] = $"{product.Name} успешно удален!";
            }
            return RedirectToAction("Index");

            
        }

    }
}
