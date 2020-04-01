using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<Measure, MeasureData>, SortedRepository<Measure, MeasureData>>
    {

        private class TestClass : FilteredRepository<Measure, MeasureData>
        {
            public TestClass(DbContext c, DbSet<MeasureData> s) : base(c, s)
            {
            }

            protected internal override Measure ToDomainObject(MeasureData d) => new Measure(d);


            protected override async Task<MeasureData> GetData(string id)
            {
                return await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string GetId(Measure entity) => entity?.Data?.Id;

        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbcontext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            var c = new QuantityDbcontext(options);
            Obj = new TestClass(c, c.Measures);
        }


        [TestMethod] public void SearchStringTest()=>IsNullableProperty(() => Obj.SearchString, x=>Obj.SearchString =x);
        

        [TestMethod] public void FixedFilterTest() => IsNullableProperty(() => Obj.FixedFilter, x => Obj.FixedFilter = x);


        [TestMethod] public void FixedValueTest() => IsNullableProperty(() => Obj.FixedValue, x => Obj.FixedValue = x);


        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var sql = Obj.CreateSqlQuery();
            Assert.IsNotNull(sql);

        }

        [TestMethod]
        public void AddFixedFilteringTest()
        {
            var sql = Obj.CreateSqlQuery();
            var fixedFilter = GetMember.Name<MeasureData>(x => x.Definition);
            Obj.FixedFilter = fixedFilter;
            var fixedValue = GetRandom.String();
            Obj.FixedValue = fixedValue;
            var sqlNew = Obj.AddFixedFiltering(sql);
            Assert.IsNotNull(sqlNew);

        }

        [TestMethod]
        public void CreateFixedWhereExpressionTest()
        {
            var properties = typeof(MeasureData).GetProperties();
            var idx = GetRandom.Int32(0, properties.Length);
            var p = properties[idx];
            Obj.FixedFilter = p.Name;
            var fixedValue = GetRandom.String();
            Obj.FixedValue = fixedValue;
            var e = Obj.CreateFixedWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();
            var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $".Contains(\"{fixedValue}\")";
                Assert.IsTrue(s.Contains(expected));
            

        }
        [TestMethod]
        public void CreateFixedWhereExpressionOnFixedFilterNullTest()
        {
            Assert.IsNull(Obj.CreateFixedWhereExpression());
            Obj.FixedValue = GetRandom.String();
            Obj.FixedFilter = GetRandom.String();
            Assert.IsNull(Obj.CreateFixedWhereExpression());


        }

        [TestMethod]
        public void AddFilteringTest()
        {
            var sql = Obj.CreateSqlQuery();
            var searchString = GetRandom.String();
            Obj.SearchString = searchString;
            var sqlNew = Obj.AddFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod]
        public void CreateWhereExpressionTest()
        {
            var searchString = GetRandom.String();
            Obj.SearchString = searchString;
            var e = Obj.CreateWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();
            foreach (var p in typeof(MeasureData).GetProperties())
            {
                var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $".Contains(\"{searchString}\")";
                Assert.IsTrue(s.Contains(expected));
            }
        }
        [TestMethod]
        public void CreateWhereExpressionIsNullSearchStringTest()
        {
            Obj.SearchString = null;
            var e = Obj.CreateWhereExpression();
            Assert.IsNull(e);
        }
    }
}
