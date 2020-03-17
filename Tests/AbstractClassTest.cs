   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using Abc.Tests;

   namespace Abc.Tests
{
    public abstract class AbstractClassTest<TClass, TBaseClass> : BaseTest<TClass, TBaseClass>
    {
       
        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(type.IsAbstract);
        }
    }
}