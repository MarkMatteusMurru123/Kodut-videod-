using System;
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
    public class PaginatedRepositoryTests : AbstractClassTests<PaginatedRepository<Measure, MeasureData>, FilteredRepository<Measure, MeasureData>>
    {


        private class TestClass : PaginatedRepository<Measure, MeasureData>
        {
            public TestClass(DbContext c, DbSet<MeasureData> s) : base(c, s)
            {
            }

            protected internal override Measure ToDomainObject(MeasureData d) => new Measure(d);


            protected override async Task<MeasureData> GetData(string id)=> await DbSet.FirstOrDefaultAsync(m => m.Id == id);
            

            protected override string GetId(Measure entity) => entity?.Data?.Id;

        }

        private byte count;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbcontext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            var c = new QuantityDbcontext(options);
            Obj = new TestClass(c, c.Measures);
            count = GetRandom.UInt8(10, 30);
            foreach (var p in c.Measures)
            {
                c.Entry(p).State = EntityState.Deleted;
            }
            AddItems();
        }
        [TestMethod] public void PageIndexTest()=>IsProperty(() => Obj.PageIndex, x => Obj.PageIndex = x);

        [TestMethod]
        public void PageSizeTest()
        {
            Assert.AreEqual(5, Obj.PageSize);
            IsProperty(() => Obj.PageSize, x => Obj.PageSize = x);
        }
        
        [TestMethod] public void TotalPagesTest()
        {
            var expected = (int) Math.Ceiling(count / (double) Obj.PageSize);
            var totalPagesCount = Obj.TotalPages;
            Assert.AreEqual(expected, totalPagesCount);
        }
        [TestMethod] public void HasNextPageTest()
        {
            void TestNextPage(int pageIndex, bool expected)
            {
                Obj.PageIndex = pageIndex; //esimesel lehel on järgmine lk
                var actual = Obj.HasNextPage;
                Assert.AreEqual(expected, actual);
            }
            TestNextPage(0, true);
            TestNextPage(GetRandom.Int32(1, Obj.TotalPages-1), true);
            TestNextPage(Obj.TotalPages, false); //järgmist pole

        }
        [TestMethod] public void HasPreviousPageTest()
        {
            void TestPreviousPage(int pageIndex, bool expected)
            {
                Obj.PageIndex = pageIndex; 
                var actual = Obj.HasPreviousPage;
                Assert.AreEqual(expected, actual);
            }
            TestPreviousPage(0, false); //eelmist pole
            TestPreviousPage(GetRandom.Int32(1, Obj.TotalPages-1), true);
            TestPreviousPage(Obj.TotalPages, true); //järgmine on

        }
        [TestMethod]
        public void GetTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(count / (double)Obj.PageSize);
            var totalPagesCount = Obj.GetTotalPages(Obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);

        }
        [TestMethod] public void CountTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(count / (double)Obj.PageSize);
            var totalPagesCount = Obj.CountTotalPages(count, Obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);

        }
        [TestMethod] public void GetItemsCountTest()
        {
            var itemsCount = Obj.GetItemsCount();
            Assert.AreEqual(count, itemsCount);
        }

        private void AddItems()
        {
            for (var i = 0; i < count; i++)
            {
                Obj.Add(new Measure(GetRandom.Object<MeasureData>())).GetAwaiter();
            }
        }

        [TestMethod] public void CreateSqlQueryTest()
        {
            var o = Obj.CreateSqlQuery();
            Assert.IsNotNull(o);
        }
        [TestMethod]
        public void AddSkipAndTakeTest()
        {
            var sql = Obj.CreateSqlQuery();
            var o = Obj.AddSkipAndTake(sql);
            Assert.IsNotNull(o);

        }
    }
}
