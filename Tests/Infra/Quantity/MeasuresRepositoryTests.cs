using System;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra.Quantity
{
    [TestClass]
    public class MeasuresRepositoryTests : RepositoryTests<MeasuresRepository, Measure, MeasureData>
    {
        private QuantityDbContext _db;
        private int _count;
        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            _db = new QuantityDbContext(options);
            Obj = new MeasuresRepository(_db);
            foreach (var e in _db.Measures)
            {
                _db.Entry(e).State = EntityState.Deleted;
            }

            _count = GetRandom.UInt8(20, 40);
            AddItems();
        }

        private void AddItems()
        {
            for (var i = 0; i < _count; i++)
            {
                Obj.Add(new Measure(GetRandom.Object<MeasureData>())).GetAwaiter();
            }
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Measure, MeasureData>);
        }

        protected override void TestGetList()
        {
            Obj.PageIndex = GetRandom.Int32(2, Obj.TotalPages - 1);
            var l = Obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(Obj.PageSize, l.Count);

        }

        protected override string GetId(MeasureData d) => d.Id;
        

        protected override Measure GetObject(MeasureData d)=>new Measure(d);


        protected override void SetId(MeasureData d, string id) => d.Id = id;

    }
}
