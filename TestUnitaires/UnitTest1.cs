using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsService1;

namespace TestUnitaires
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAnneeMoisPrecedent()
        {
            GestionDate gd = new GestionDate();
            Assert.AreEqual("201704", gd.getAnneeMoisPrecedent());
        }
    }
}
