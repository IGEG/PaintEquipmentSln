
using PaintEquipment.Models;
using Microsoft.AspNetCore.Mvc;

namespace PaintEquipment.Components
{
    public class CartFontAwesomViewComponent:ViewComponent
    {
        private CartAll cart;
        public CartFontAwesomViewComponent( CartAll _cart)
        {
            cart = _cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
       
    }
}
