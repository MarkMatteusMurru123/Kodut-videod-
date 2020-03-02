using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class ClassTest<TClass, TBaseClass>: BaseTest<TClass, TBaseClass> where TClass : new()
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            obj = new TClass();
            type = GetType();
        }
        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(obj);
        }
         
    }
}