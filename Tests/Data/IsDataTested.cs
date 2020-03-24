using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        private const string assembly = "Abc.Data";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsCommonTested() {IsAllTested(assembly, Namespace("Common"));}
        [TestMethod] public void IsMoneyTested() { IsAllTested(assembly, Namespace("Money"));}
        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity"));}
        [TestMethod] public void IsTested() { IsAllTested(assembly, base.Namespace("Data")); }


    }
}
