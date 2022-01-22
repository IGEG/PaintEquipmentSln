using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PaintEquipment.Controllers;
using PaintEquipment.Models;
using Xunit;

namespace PaintEquipment.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void CanControllerUseRepository()
        {
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(p => p.Products).Returns((new Product[] {
            new Product{ Id =1, Name="Name1"},
            new Product{ Id =2, Name="Name2"}
            }).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);

            IEnumerable<Product> result = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Product>;

            Product [] products = result.ToArray();
            Assert.True(products.Length == 2);
            Assert.Equal(1,products[0].Id);
            Assert.Equal("Name2", products[1].Name);


        }
    }
}
