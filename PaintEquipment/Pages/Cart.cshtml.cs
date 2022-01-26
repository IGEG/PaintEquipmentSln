using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaintEquipment.Infrastructure;
using PaintEquipment.Models;
using System.Linq;

namespace PaintEquipment.Pages
{
    public class CartModel : PageModel
    {
        IAppRepository appRepository;
        public CartModel(IAppRepository app)
        {
            appRepository = app;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string retutnUrl)
        {
            ReturnUrl = retutnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long id, string returnUrl)
        {
            Product product = appRepository.Products.FirstOrDefault(x => x.Id == id);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddRow(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
