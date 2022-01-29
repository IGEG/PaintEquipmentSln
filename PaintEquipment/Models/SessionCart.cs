using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PaintEquipment.Infrastructure;

namespace PaintEquipment.Models
{
    public class SessionCart:CartAll
    {
        public static CartAll GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("CartAll") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddRow(Product product, int quantity)
        {
            base.AddRow(product, quantity);
            Session.SetJson("CartAll", this);
        }
        public override void DeleteRow(Product product)
        {
            base.DeleteRow(product);
            Session.SetJson("CartAll", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("CartAll");
        }

    }
}
