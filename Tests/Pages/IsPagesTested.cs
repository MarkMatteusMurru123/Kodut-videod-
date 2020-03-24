using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages
{
    [TestClass]
    public class IsPagesTested : AssemblyTests
    {

        private const string assembly = "Abc.Pages";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsExtensionsTested() { IsAllTested(assembly, Namespace("Extensions")); }
        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { IsAllTested(assembly, base.Namespace("Pages")); }

    }
}
