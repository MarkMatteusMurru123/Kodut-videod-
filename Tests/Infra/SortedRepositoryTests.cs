using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTest<SortedRepository<Measure, MeasureData>, BaseRepository<Measure, MeasureData>>
    {
        private class tesClass : SortedRepository<Measure, MeasureData>
        {
            public tesClass(DbContext c, DbSet<MeasureData> s) : base(c, s)
            {
            }

            protected override Task<MeasureData> GetData(string id)
            {
                throw new NotImplementedException();
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var c = new QuantityDbcontext(new DbContextOptions<QuantityDbcontext>());
            obj = new tesClass(c,c.Measures);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SetSortingTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetNameTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IsDescendingTest()
        {
            obj.SortOrder = GetRandom.String();
            Assert.IsFalse(obj.IsDescending());
            obj.SortOrder += obj.DescendingString;
            Assert.IsTrue(obj.IsDescending());
        }
    }

}
