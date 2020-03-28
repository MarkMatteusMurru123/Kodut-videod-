using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Quantity
{
    [TestClass]
    public class CommonTermDataTests :AbstractClassTests<CommonTermData, PeriodData>
    {
       private class TestClass : CommonTermData { }
        [TestInitialize]
       public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod] public void MasterIdTest()
        {
            IsNullableProperty(() => Obj.MasterId,x=> Obj.MasterId=x);
        }
        [TestMethod]
        public void TermIdTest()
        {
            IsNullableProperty(() => Obj.TermId, x => Obj.TermId = x);
        }
        [TestMethod]
        public void PowerTest()
        {
            IsProperty(() => Obj.Power, x => Obj.Power = x);
        }
    }
}
