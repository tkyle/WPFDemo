using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFDemo.Business.BusinessObjects;

namespace WPFDemo.Test
{
    [TestClass]
    public class EmployeeListTest
    {
        [TestMethod]
        public void EmployeeList_GetEmployeeList_Should_Return_Objects()
        {
            var obj = EmployeeList.GetEmployeeList();
            Assert.IsTrue(obj.Count > 0);
        }
    }
}
