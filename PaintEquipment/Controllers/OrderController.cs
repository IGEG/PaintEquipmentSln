using PaintEquipment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace PaintEquipment.Controllers
{
    public class OrderController:Controller
    {
        private IAppOrder repository;
        private CartAll cart;

        public OrderController(IAppOrder repoService, CartAll cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Rows.Count == 0)
            {
                ModelState.AddModelError("", "В карзине нет товара!");
            }
            if (ModelState.IsValid)
            {
                order.Rows = cart.Rows.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.ClearCart();
            return View();
        }
    }
}