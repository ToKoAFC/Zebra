using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zebra.Database;
using Zebra.Database.Access;
using Zebra.Database.Models;

namespace Zebra.Tests
{    
    [TestClass]
    public class UnitTest1
    {
        private readonly ProductAccess access = new ProductAccess(new ZebraContext());
        //update test
        [TestMethod]
        public void GetCoreProductEntities()
        {
            access.GetCoreProduct();
        }
        [TestMethod]
        public void GetCoreProductSQL()
        {
            access.GetCoreProductSQL();
        }
    }
}
