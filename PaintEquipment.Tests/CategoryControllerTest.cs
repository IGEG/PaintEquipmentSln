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

    public class CategoryControllerTest
    {
        [Fact]
        public void CanGetProductFromURL()
        {
            //arrange
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(p => p.Products).Returns((new Product[] {
new Product { Id=1,Name="1",URLadress="product1",CategoryId=1},
new Product { Id=2,Name="2",URLadress="product2",CategoryId=1},
new Product { Id=3,Name="3",URLadress="product3",CategoryId=1}
            }).AsQueryable<Product>());
            //arrange
            CategoryController controller = new CategoryController(mock.Object, null);
            //act
            Product result = (controller.Product("product1") as ViewResult).ViewData.Model as Product;
            //Asser
            Assert.Equal(1, result.Id);


        }
        [Fact]
        public void CanIndexReturneProductFromRepository()
        {
            //arrange
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(p => p.Products).Returns((new Product[] {
            new Product { Id=1,Name="1",URLadress="product1",CategoryId=1},
new Product { Id=2,Name="2",URLadress="product2",CategoryId=1},
new Product { Id=3,Name="3",URLadress="product3",CategoryId=1}
            }).AsQueryable<Product>());
            CategoryController controller = new CategoryController(mock.Object, null);
            //action
            ProductListViewModel result = (controller.Index(null) as ViewResult).ViewData.Model as ProductListViewModel;
            Product[] products = result.Products.ToArray();
            //assert
            Assert.NotNull(products[0]);

        }

        [Fact]
        public void CanAddenNewRequest()
        {
            //arrange
            Mock<IAppProductRequest> mock = new Mock<IAppProductRequest>();
            mock.Setup(c => c.productRequests).Returns((new ProductRequest[] {
new ProductRequest { Id = 1, Name = "request1",Email = "i@i.ru", Number="1", Desc="1" },
new ProductRequest { Id = 2, Name = "request2",Email = "i@u.ru", Number="2", Desc="2" }
            }).AsQueryable<ProductRequest>());
            CategoryController controller = new CategoryController(null,mock.Object);
            //act
            ProductRequest ProductRequest = new ProductRequest { Id = 3, Name = "request3", Email = "i@u.ru", Number = "3", Desc = "3" };
            RedirectToActionResult result =  controller.SaveProductRequst(ProductRequest) as RedirectToActionResult;
            //assert
            Assert.Equal("CompletedProductRequest", result.ActionName);
            
        }





    }
}
