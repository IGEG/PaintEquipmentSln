using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PaintEquipment.Controllers;
using PaintEquipment.Models;
using PaintEquipment.Models.ViewModels;
using Xunit;
using System.Linq;

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

            ProductListViewModel result = (controller.Index(null) as ViewResult).ViewData.Model as ProductListViewModel;

            Product[] products = result.Products.ToArray();
            Assert.True(products.Length == 2);
            Assert.Equal(1, products[0].Id);
            Assert.Equal("Name2", products[1].Name);

        }
        [Fact]
        public void CanPagesSeporetedByQuantityOfProduct()
        {
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(p => p.Products).Returns((new Product[] {
            new Product{ Id =1, Name="Name1"},
            new Product{ Id =2, Name="Name2"},
            new Product{ Id =3, Name="Name3"},
            new Product{ Id =4, Name="Name4"},
            new Product{ Id =5, Name="Name5"},
            new Product{ Id =6, Name="Name6"}
            }).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel result = (controller.Index(null, 2) as ViewResult).ViewData.Model as ProductListViewModel;

            Product[] productarray = result.Products.ToArray();
            Assert.True(productarray.Length == 3);
            Assert.Equal(4, productarray[0].Id);
            Assert.Equal("Name6", productarray[2].Name);

        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {

            // Arrange
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {Id = 1, Name = "P1"},
                new Product {Id = 2, Name = "P2"},
                new Product {Id = 3, Name = "P3"},
                new Product {Id = 4, Name = "P4"},
                new Product {Id = 5, Name = "P5"}
            }).AsQueryable<Product>());

            // Arrange
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel result = (controller.Index(null, 2) as ViewResult).ViewData.Model as ProductListViewModel;

            // Act


            // Assert
            PageInfo pageInfo = result.PageInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.QuantityProductOnPage);
            Assert.Equal(5, pageInfo.TotalProduct);
            Assert.Equal(2, pageInfo.TotalPages);
        }

    
      
    }
}
