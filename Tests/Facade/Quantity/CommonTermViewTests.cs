using Abc.Facade.Common;
using Abc.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Quantity
{
   [TestClass]
    public class CommonTermViewTests :AbstractClassTests<CommonTermView, PeriodView>
    {
        private class TestClass :CommonTermView
        {
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void TermIdTest() => IsNullableProperty(() => Obj.TermId, x => Obj.TermId = x);
        [TestMethod]
        public void PowerTest() => IsProperty(() => Obj.Power, x => Obj.Power = x);
    }
}
