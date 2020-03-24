using Abc.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Common
{
    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, PeriodView>
    {
        private class TestClass : UniqueEntityView { }
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