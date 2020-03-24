using Abc.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Common
{
    [TestClass]
    public class UniqueEntityDataTests : AbstractClassTests<UniqueEntityData, PeriodData>
    {
        private class TestClass : UniqueEntityData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }
        [TestMethod]
        public void IdTest()
        {
            IsNullableProperty(() => Obj.Id, x => Obj.Id = x);
        }
    }
}