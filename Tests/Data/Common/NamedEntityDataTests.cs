using Abc.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Common
{
    [TestClass]
    public class NamedEntityDataTests : AbstractClassTests<NamedEntityData, UniqueEntityData>
    {
        private class TestClass : NamedEntityData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }
        [TestMethod]
        public void NameTest()
        {
            IsNullableProperty(() => Obj.Name, x => Obj.Name = x);
        }
        [TestMethod]
        public void CodeTest()
        {
            IsNullableProperty(() => Obj.Code, x => Obj.Code = x);
        }
    }
}