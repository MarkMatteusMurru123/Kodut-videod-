using Abc.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Common
{
    [TestClass]
    public class DefinedEntityDataTests : AbstractClassTests<DefinedEntityData, NamedEntityData>
    {
        private class TestClass : DefinedEntityData { }
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