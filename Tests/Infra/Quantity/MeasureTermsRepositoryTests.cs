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
    public class MeasureTermsRepositoryTests : RepositoryTests<MeasureTermsRepository, MeasureTerm, MeasureTermData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            Db = new QuantityDbContext(options);
            DbSet = ((QuantityDbContext)Db).MeasureTerms;
            Obj = new MeasureTermsRepository((QuantityDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(PaginatedRepository<MeasureTerm, MeasureTermData>);
        }


        protected override string GetId(MeasureTermData d) => $"{d.MasterId}.{d.TermId}"; //composite key


        protected override MeasureTerm GetObject(MeasureTermData d) => new MeasureTerm(d);


        protected override void SetId(MeasureTermData d, string id)
        {
            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);
            d.MasterId = masterId;
            d.TermId = termId;
        }

    }
   
}
