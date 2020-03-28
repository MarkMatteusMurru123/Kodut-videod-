using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Quantity
{
    [TestClass]
    public class CommonTermDataTests :AbstractClassTests<CommonTermData, PeriodData>
    {
       private class TestClass : CommonTermData { }
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod] public void MasterIdTest()
        {
            IsNullableProperty(() => Obj.MasterId,x=> Obj.MasterId=x);
        }
    }
}
