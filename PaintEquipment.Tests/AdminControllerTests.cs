using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PaintEquipment.Models;
using PaintEquipment.Controllers;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PaintEquipment.Models.ViewModels;

namespace PaintEquipment.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void CanGetProductInView()
        {

            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]{
            new Product { Id=1,Name="P1"},
            new Product { Id = 2, Name = "P2" },
            new Product { Id = 3, Name = "P3" },
            }).AsQueryable<Product>());
            AdminController controller = new AdminController(mock.Object);
            Product[] products = GetViewModel<IEnumerable<Product>>(controller.Index())?.ToArray();
            Assert.Equal(3, products.Length);
            Assert.Equal("P2", products[1].Name);


        }

        [Fact]
        public void CanEditProduct()
        {
            Mock<IAppCategory> mockcategory = new Mock<IAppCategory>();
            mockcategory.Setup(c => c.categories).Returns((new Category[] {
            new Category {Id=1,Name="1" },
            new Category {Id=2,Name="2" }
            }).AsQueryable<Category>());
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]{
            new Product { Id = 1, Name = "P1", CategoryId=1 },
            new Product { Id = 2, Name = "P2", CategoryId=1 },
            new Product { Id = 3, Name = "P3", CategoryId=1 }
            }).AsQueryable<Product>());
            AdminController controller = new AdminController(mock.Object,mockcategory.Object);
            ProductViewModel product = (controller.Edit(1) as ViewResult).ViewData.Model as ProductViewModel;
            Assert.Equal(1, product.product.Id);

        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
