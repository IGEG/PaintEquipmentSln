using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaintEquipment.Models.ViewModels;

namespace PaintEquipment.Controllers
{
    //[Authorize]
    public class AdminController:Controller
    {
        IAppRepository repository;
        IAppRequest request;
        IAppCategory category;
        IAppProductRequest productRequest;
      
        public AdminController(IAppRepository repo, IAppRequest req, IAppCategory cat, IAppProductRequest prodreq)
        {
            repository = repo;
            request=req;
            category = cat;
            productRequest = prodreq;
        }

        //products
        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int ID)
        {
            
            return View( new ProductViewModel { product= repository.Products.FirstOrDefault(p => p.Id == ID), categories=category.categories });
        }

        [HttpPost]

        public IActionResult Edit(ProductViewModel newProduct)
        {


            //if (ModelState.IsValid)
            //{
               
                repository.SaveProduct(newProduct.product);
                TempData["message"] = $"{newProduct.product.Name} успешно сохранен!";
                return RedirectToAction(nameof(Index));
            //}
            //return View(product);
        }
        public ViewResult Create()
        {
            
            return  View("Edit", new ProductViewModel {product=new Product(), categories = category.categories });
        }

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

        //request from product page

        public ViewResult ListProductRequest() => View(productRequest.productRequests);

        [HttpPost]
        public IActionResult DeleteProductRequests(int ID)
        {
            productRequest.DeleteRequest(ID);

            return RedirectToAction(nameof(ListProductRequest));
        }


    }
}
