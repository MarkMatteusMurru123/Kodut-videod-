using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests
{
    public abstract class ClassTests<TClass, TBaseClass>: BaseClassTests<TClass, TBaseClass> where TClass : new()
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            Obj = new TClass();
            Type = Obj.GetType();
        }
        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(Obj);
        }
         
    }
}