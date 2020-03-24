using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
        
        private const string assembly = "Abc.Domain";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsCommonTested() { IsAllTested(assembly, Namespace("Common")); }
        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { IsAllTested(assembly, base.Namespace("Domain")); }

    }
}
