using Abc.Facade.Common;
using Abc.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitFactorViewTests : SealedClassTests<UnitFactorView, PeriodView>
    {
        [TestMethod] public void UnitIdTest() => IsNullableProperty(() => Obj.UnitId, x => Obj.UnitId = x);
        [TestMethod] public void SystemOfUnitsIdTest() => IsNullableProperty(() => Obj.SystemOfUnitsId, x => Obj.SystemOfUnitsId = x);
        [TestMethod] public void FactorTest() => IsProperty(() => Obj.Factor, x => Obj.Factor = x);
        [TestMethod]
        public void GetIdTest()
        {
            var actual = Obj.GetId();
            var expected = $"{Obj.SystemOfUnitsId}.{Obj.UnitId}";
            Assert.AreEqual(expected, actual);
        }
    }
}
