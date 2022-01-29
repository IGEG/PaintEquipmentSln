using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PaintEquipment.Models;
using System.Linq;

namespace PaintEquipment.Tests
{
    public class CartTest
    {
        [Fact]
        public void CanAddedProductToCart()
        {
            Product p1 = new Product { Id = 1, Name = "Product1" };
            Product p2 = new Product { Id = 2, Name = "Product2" };
            CartAll cart = new CartAll();
            cart.AddRow(p1, 1);
            cart.AddRow(p2, 2);
            cart.AddRow(p2, 8);
            CartRow[] cartRows = cart.Rows.OrderBy(x => x.Product.Id).ToArray();
            Assert.Equal(2, cartRows.Length);
            Assert.Equal("Product2", cartRows[1].Product.Name);
            Assert.Equal(10, cartRows[1].Quantity);

        }

        [Fact]
        public void CandDeletedRowFromCrt()
        {
            Product p1 = new Product { Id = 1, Name = "Product1" };
            Product p2 = new Product { Id = 2, Name = "Product2" };
            CartAll cart = new CartAll();
            cart.AddRow(p1, 1);
            cart.AddRow(p2, 2);
            cart.AddRow(p2, 8);
            cart.DeleteRow(p1);
            CartRow[] cartrow = cart.Rows.ToArray();
            Assert.Empty(cartrow.Where(p=>p.Product.Id==1));
           
        }

        [Fact]
        public void CandSummAllProductPriceInCrt()
        {
            Product p1 = new Product { Id = 1, Name = "Product1", Price=100 };
            Product p2 = new Product { Id = 2, Name = "Product2", Price=200 };
            CartAll cart = new CartAll();
            cart.AddRow(p1, 1);
            cart.AddRow(p2, 2);
            
            CartRow[] cartrow = cart.Rows.ToArray();
            decimal sumcart = cart.GetTotalSum();
            Assert.Equal(500, sumcart);

        }
        [Fact]
        public void CanEmptyAllProductInCart()
        {
            Product p1 = new Product { Id = 1, Name = "Product1", Price = 100 };
            Product p2 = new Product { Id = 2, Name = "Product2", Price = 200 };
            CartAll cart = new CartAll();
            cart.AddRow(p1, 1);
            cart.AddRow(p2, 2);
            cart.ClearCart();
            Assert.True(cart.Rows.Count==0);

        }
    }
}
