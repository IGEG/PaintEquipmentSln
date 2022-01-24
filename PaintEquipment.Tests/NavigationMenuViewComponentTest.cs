﻿using PaintEquipment.Models;
using PaintEquipment.Components;
using Xunit;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace PaintEquipment.Tests
{
    public class NavigationMenuViewComponentTest
    {
        [Fact]
        public void CanNavigationMenuSortedCategory()
        {
            Mock<IAppRepository> mock = new Mock<IAppRepository>();
            mock.Setup(x=>x.Products).Returns((new Product[] {
                new Product {Id = 1, Name = "P1", Category="def"},
                new Product {Id = 2, Name = "P2", Category="abc"},
                new Product {Id = 3, Name = "P3", Category="ghk"},
            }).AsQueryable<Product>());
            NavigationMenuViewComponent navigationMenu = new NavigationMenuViewComponent(mock.Object);
            string [] result = ((IEnumerable<string>)(navigationMenu.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();
            Assert.True(Enumerable.SequenceEqual(result, new string[] { "abc", "def", "ghk" }));
        
        
        }
    }
}
