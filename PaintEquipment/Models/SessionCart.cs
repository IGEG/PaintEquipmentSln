using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PaintEquipment.Infrastructure;

namespace PaintEquipment.Models
{
    public class SessionCart:Cart
    {
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddRow(Product product, int quantity)
        {
            base.AddRow(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void DeleteRow(Product product)
        {
            base.DeleteRow(product);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }

    }
}
