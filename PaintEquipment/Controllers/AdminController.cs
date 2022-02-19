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
        IAppRequest request;
        IAppCategory category;
      
        public AdminController(IAppRepository repo, IAppRequest req, IAppCategory cat)
        {
            repository = repo;
            request=req;
            category = cat;
        }

        //products
        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int ID)
        {
            ViewBag.Categories = category.categories;
            return View(repository.Products.FirstOrDefault(p => p.Id == ID));
        }

        [HttpPost]

        public IActionResult Edit(Product product)
        {
            ViewBag.Categories = category.categories;
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

        //categories
        public ViewResult ListCategories() => View(category.categories);

  

        public ViewResult EditCategory(int ID) => View(category.categories.FirstOrDefault(c => c.Id == ID));

        [HttpPost]

        public IActionResult EditCategory(Category cat)
        {
            if (ModelState.IsValid)
            {
                category.EditCategory(cat);
                TempData["message"] = $"{cat.Name} успешно сохранен!";
                return RedirectToAction(nameof(ListCategories));
            }
            return View(cat);
        }
        public ViewResult CreateCategory() => View("EditCategory", new Category());

        [HttpPost]

        public IActionResult DeleteCategory(int ID)
        {
            Category cat = category.DeleteCategory(ID);
            if (cat != null)
            {
                TempData["message"] = $"{cat.Name} успешно удален!";
            }
            return RedirectToAction(nameof(ListCategories));


        }
        //request from main page

        public ViewResult ListRequest() => View(request.Requests);

        [HttpPost]
        public IActionResult DeleteRequests(int ID)
        {
                request.DeleteRequest(ID);
           
            return RedirectToAction(nameof(ListRequest));
        }
      
       
    }
}
