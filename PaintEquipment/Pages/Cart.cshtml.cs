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
        public CartModel(IAppRepository app, CartAll cartService)
        {
            appRepository = app;
            Cart = cartService;
        }
        public CartAll Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string retutnUrl)
        {
            ReturnUrl = retutnUrl ?? "/";
            
        }
        public IActionResult OnPost(long ID, string returnUrl)
        {
            Product product = appRepository.Products.FirstOrDefault(x=>x.Id==ID);
            Cart.AddRow(product, 1);
            return RedirectToPage(new {returnUrl=returnUrl });
        }
        public IActionResult OnPostRemove(long ID, string returnUrl)
        {
            Cart.DeleteRow(Cart.Rows.First(cl => cl.Product.Id == ID).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
