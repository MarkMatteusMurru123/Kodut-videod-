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

        private byte _count;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            var c = new QuantityDbContext(options);
            Obj = new TestClass(c, c.Measures);
            _count = GetRandom.UInt8(20, 40);
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
            var expected = (int) Math.Ceiling(_count / (double) Obj.PageSize);
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
            TestNextPage(1, true);
            TestNextPage(GetRandom.Int32(2, Obj.TotalPages-1), true);
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
            TestPreviousPage(1, false); 
            TestPreviousPage(2, true);
            TestPreviousPage(GetRandom.Int32(2, Obj.TotalPages), true);
            TestPreviousPage(Obj.TotalPages, true); //järgmine on

        }
        [TestMethod]
        public void GetTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(_count / (double)Obj.PageSize);
            var totalPagesCount = Obj.GetTotalPages(Obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);

        }
        [TestMethod] public void CountTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(_count / (double)Obj.PageSize);
            var totalPagesCount = Obj.CountTotalPages(_count, Obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);

        }
        [TestMethod] public void GetItemsCountTest()
        {
            var itemsCount = Obj.GetItemsCount();
            Assert.AreEqual(_count, itemsCount);
        }

        private void AddItems()
        {
            for (var i = 0; i < _count; i++)
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
