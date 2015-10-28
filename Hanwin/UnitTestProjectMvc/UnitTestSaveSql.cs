using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace UnitTestProjectMvc
{
    [TestClass]
    public class UnitTestSaveSql
    {
        [TestMethod]
        public void SaveSqlTest()
        {
            TypesBLL target = new TypesBLL(); // TODO: Initialize to an appropriate value  
            Types t = null; // TODO: Initialize to an appropriate value  
            target.SaveTypes(t);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");  
        }
    }
}
