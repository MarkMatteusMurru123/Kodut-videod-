using Abc.Data.Common;
using Abc.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Common
{
    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedView, UniqueEntityView>
    {
        private class TestClass : NamedView { }
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