using System;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra.Quantity
{
    [TestClass]
    public class UnitsRepositoryTests : RepositoryTests<UnitsRepository, Unit,UnitData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            Db = new QuantityDbContext(options);
            DbSet = ((QuantityDbContext)Db).Units;
            Obj = new UnitsRepository((QuantityDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType() => typeof(UniqueEntityRepository<Unit, UnitData>);

        protected override string GetId(UnitData d) => d.Id;
        

        protected override Unit GetObject(UnitData d) => new Unit(d);


        protected override void SetId(UnitData d, string id) => d.Id = id;
        
    }
}
