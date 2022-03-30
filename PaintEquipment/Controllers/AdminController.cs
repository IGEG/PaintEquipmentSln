using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaintEquipment.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace PaintEquipment.Controllers
{
    //[Authorize]
    public class AdminController:Controller
    {
        IAppRepository repository;
        IAppRequest request;
        IAppCategory category;
        IAppProductRequest productRequest;
        IWebHostEnvironment hosting;

        public AdminController(IAppRepository repo)
        {
            repository = repo;
        }

        public AdminController(IAppRepository repo, IAppCategory cat)
        {
            repository = repo;
            category = cat;
        }
        public AdminController(IAppRepository repo, IAppRequest req, IAppCategory cat, IAppProductRequest prodreq, IWebHostEnvironment host)
        {
            repository = repo;
            request=req;
            category = cat;
            productRequest = prodreq;
            hosting = host;
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


            if (!ModelState.IsValid)
            {

                repository.SaveProduct(newProduct.product);
                //id product
                var productID = newProduct.product.Id;
                // получаем адрес картинки
                var wwwrootpath = hosting.WebRootPath;
                // получаем файл картинки
                var files = HttpContext.Request.Form.Files;
                // ссылка на сохранение в базу
                var savedProduct = repository.Products.FirstOrDefault(p => p.Id == productID);
                //загрузка файла на сервер и сохранение пути доступа к картинке
                if (files.Count != 0)
                {
                    var imagePath = @"\Lib\Img\";
                    var extension = Path.GetExtension(files[0].FileName);
                    var relativImagePath = imagePath + productID + extension;
                    var absImagePath = wwwrootpath + relativImagePath;
                    using (var fileStream = new FileStream(absImagePath, FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    savedProduct.Img = relativImagePath;
                    repository.SaveProduct(savedProduct);
                    TempData["message"] = $"{savedProduct.Name} успешно сохранен!";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newProduct);
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
