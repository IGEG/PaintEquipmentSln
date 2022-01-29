using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Moq;
using PaintEquipment.Models;
using PaintEquipment.Pages;
using System.Linq;
using System.Text;
using System.Text.Json;
using Xunit;

namespace PaintEquipment.Tests
{
    public class CartPageTests
    {
        [Fact]
        public void Can_Load_Cart()
        {

            // Arrange
            // - create a mock repository
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };
            Mock<IAppRepository> mockRepo = new Mock<IAppRepository>();
            mockRepo.Setup(m => m.Products).Returns((new Product[] {
        p1, p2
    }).AsQueryable<Product>());

            // - create a cart 
            CartAll testCart = new CartAll();
            testCart.AddRow(p1, 2);
            testCart.AddRow(p2, 1);

            // Action
            CartModel cartModel = new CartModel(mockRepo.Object, testCart);
            cartModel.OnGet("myUrl");

            //Assert
            Assert.Equal(2, cartModel.Cart.Rows.Count());
            Assert.Equal("myUrl", cartModel.ReturnUrl);
        }

        [Fact]
        public void Can_Update_Cart()
        {
            // Arrange
            // - create a mock repository
            Mock<IAppRepository> mockRepo = new Mock<IAppRepository>();
            mockRepo.Setup(m => m.Products).Returns((new Product[] {
        new Product { Id = 1, Name = "P1" }
    }).AsQueryable<Product>());

            CartAll testCart = new CartAll();


            // Action
            CartModel cartModel = new CartModel(mockRepo.Object, testCart);
            cartModel.OnPost(1, "myUrl");

            //Assert
            Assert.Single(testCart.Rows);
            Assert.Equal("P1", testCart.Rows.First().Product.Name);
            Assert.Equal(1, testCart.Rows.First().Quantity);
        }


    }
}
