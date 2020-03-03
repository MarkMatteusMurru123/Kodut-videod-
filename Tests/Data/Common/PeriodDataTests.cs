using System;
using System.Security.Cryptography.X509Certificates;
using Abc.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTest<PeriodData, object>
    {
        private class TestClass : PeriodData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
        [TestMethod]
        public void ValidFromTest()
        {
            isNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom = x, () => DateTime.Now);
        }

        [TestMethod]
        public void ValidToTest()
        {
            isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x, () => DateTime.Now); 
        }
    }
}