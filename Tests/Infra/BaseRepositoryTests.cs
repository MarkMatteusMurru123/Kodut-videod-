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
    public class BaseRepositoryTests : AbstractClassTests<BaseRepository<Measure, MeasureData>, object>
    {
        private MeasureData data;  

        private class TestClass : SortedRepository<Measure, MeasureData>
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
            data = GetRandom.Object<MeasureData>();//loon objekti
        }
        [TestMethod]
        public void GetTest()
        {
            var count  = GetRandom.UInt8(5, 10);
            var countBefore = Obj.Get().GetAwaiter().GetResult().Count;
            for (int i = 0; i < count; i++)
            {
                data = GetRandom.Object<MeasureData>();
                AddTest();
            }
            Assert.AreEqual(count + countBefore, Obj.Get().GetAwaiter().GetResult().Count);
            

        }

        [TestMethod] public void GetByIdTest()
        {
            AddTest();
        }

        [TestMethod]
        public void DeleteTest()
        {
            AddTest();
            var expected = Obj.Get(data.Id).GetAwaiter().GetResult(); 
            TestArePropertyValuesEqual(data, expected.Data);
            Obj.Delete(data.Id).GetAwaiter();
            expected = Obj.Get(data.Id).GetAwaiter().GetResult(); //vastandtehe addiga.
            Assert.IsNull(expected.Data);


        }

        [TestMethod]
        public void  AddTest()
        {
            var expected = Obj.Get(data.Id).GetAwaiter().GetResult(); //andmebaasist measure objekt kätte id järgi
            Assert.IsNull(expected.Data);
            Obj.Add(new Measure(data)).GetAwaiter(); //Lisan measureobjekti andmebaasi, enam pole null.
            expected = Obj.Get(data.Id).GetAwaiter().GetResult(); //andmebaasist measure objekt kätte
            TestArePropertyValuesEqual(data, expected.Data);
        }
        [TestMethod]
        public void UpdateTest()
        {
            AddTest();
            var newData = GetRandom.Object<MeasureData>();//loob uue randomi.
            newData.Id = data.Id;
            Obj.Update(new Measure(newData)).GetAwaiter();
            var expected = Obj.Get(data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(newData,expected.Data);
        }
    }
}
