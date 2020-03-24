using Abc.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTests<PeriodData, object>
    {
        private class TestClass : PeriodData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }
        [TestMethod]
        public void ValidFromTest()
        {
            IsNullableProperty(() => Obj.ValidFrom, x => Obj.ValidFrom = x);
        }

        [TestMethod]
        public void ValidToTest()
        {
            IsNullableProperty(() => Obj.ValidTo, x => Obj.ValidTo = x); 
        }   
    }
}