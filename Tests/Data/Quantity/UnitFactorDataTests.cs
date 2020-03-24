using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Quantity
{
    [TestClass]
    public class UnitFactorDataTests : SealedClassTests<UnitFactorData, PeriodData>
    {
        [TestMethod]
        public void FactorTest()
        {
            IsProperty(() => Obj.Factor, x => Obj.Factor = x);
        }

        

        [TestMethod]
        public void SystemOfUnitsIdTest()
        {
            IsNullableProperty(() => Obj.SystemOfUnitsId, x => Obj.SystemOfUnitsId = x);
        }
        [TestMethod]
        public void UnitIdTest()
        {
            IsNullableProperty(() => Obj.UnitId, x => Obj.UnitId = x);
        }
    }
}