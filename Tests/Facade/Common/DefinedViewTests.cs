using Abc.Data.Common;
using Abc.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Common
{
    [TestClass]
    public class DefinedViewTests : AbstractClassTests<DefinedView, NamedView>
    {
        private class TestClass : DefinedView { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }
        [TestMethod]
        public void DefinitionTest()
        {
            IsNullableProperty(()=>Obj.Definition, x=>Obj.Definition = x);
        }
    }       
}