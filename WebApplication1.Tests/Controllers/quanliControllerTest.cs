using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class quanliControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new ExpenditureEntities(); 
            var controller = new quanliController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Quanlichitieu>));
            Assert.AreEqual(db.Quanlichitieux.Count(),(result.Model as List<Quanlichitieu>).Count);
        }
    }
}
