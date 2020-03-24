using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Quantity
{
    [TestClass]
    public class UnitDataTests : SealedClassTests<UnitData, DefinedEntityData>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            IsNullableProperty(() => Obj.MeasureId, x => Obj.MeasureId = x);
        }
    }
}
