using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<MeasureData>, object>
    {
        private class TestClass : Entity<MeasureData>
        {
            public TestClass(MeasureData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void DataTest()
        {
            var d = GetRandom.Object<MeasureData>();
            Assert.AreNotSame(d, Obj.Data);
            Obj = new TestClass(d);
            Assert.AreSame(d, Obj.Data);
        }
        [TestMethod]
        public void DataIsNullTest()
        {
            var d = GetRandom.Object<MeasureData>();
            Assert.IsNull(Obj.Data);
            Obj.Data = d;
            Assert.AreSame(d, Obj.Data);
        }
        [TestMethod]
        public void CanSetNullDataTest()
        {
            Obj.Data = null;
            Assert.IsNull(Obj.Data);
        }
    }
}
