using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string assembly = "Abc.Infra";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { IsAllTested(assembly, base.Namespace("Infra")); }
    }
}
