using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PaintEquipment.Models;
using Microsoft.AspNetCore.Http;
using PaintEquipment.Infrastructure;
using PaintEquipment.Models.ViewModels;

namespace PaintEquipment.Controllers
{
    public class CartAllController:Controller
    {
        private readonly IAppRepository app;
        private CartAll _cart;
        public CartAllController(IAppRepository appRepository, CartAll cartAll)
        {
            app=appRepository;
            _cart=cartAll;
        }

        public ViewResult AllProductInCart(string returnUrl)
        {
            return View(new CartViewModel { Cart = _cart, ReturnUrl = returnUrl });
                
        }
        public RedirectToActionResult AddToCart(int ID, string returnUrl)
        {
            Product product = app.Products.FirstOrDefault(x => x.Id == ID);
            if (product != null)
            {
                _cart.AddRow(product, 1);
            }
            return RedirectToAction("AllProductInCart", new { returnUrl});
        
        }

        public RedirectToActionResult DeleteProductFromCart(int ID, string returnUrl)
        {
            Product product = app.Products.FirstOrDefault(x => x.Id == ID);
            if (product != null)
            {
                _cart.DeleteRow(product);
            }
            return RedirectToAction("AllProductInCart", new { returnUrl });

        }

    }
}
