using Microsoft.AspNetCore.Mvc;
using PaintEquipment.Models;
using PaintEquipment.Models.ViewModels;
using System.Linq;

namespace PaintEquipment.Controllers
{
    public class CategoryController : Controller
    {
        private IAppRepository repository;
        public int PageSize = 12;
        public CategoryController(IAppRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string category, int numerPage = 1) => View(new ProductListViewModel
        {
            Products = repository.Products.Where(p => category == null || p.Category.Name == category)
            .OrderBy(p => p.Id).Skip((numerPage - 1) * PageSize).Take(PageSize),
            PageInfo = new PageInfo
            {
                CurrentPage = numerPage,
                QuantityProductOnPage = PageSize,
                TotalProduct = category == null ?
                repository.Products.Count() :
                repository.Products.Where(e => e.Category.Name == category).Count()
            },
            CurrentCategory = category,
        });

        public ViewResult Product(string URLadress)
        {
            Product product = repository.Products.FirstOrDefault(p => p.URLadress == URLadress);
            ViewBag.Title = product.Name;
            return View(product);
        }
    }
}
