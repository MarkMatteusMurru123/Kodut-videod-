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
    public class UnitTermsRepositoryTests : RepositoryTests<UnitTermsRepository, UnitTerm, UnitTermData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            Db = new QuantityDbContext(options);
            DbSet = ((QuantityDbContext)Db).UnitTerms;
            Obj = new UnitTermsRepository((QuantityDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(PaginatedRepository<UnitTerm, UnitTermData>);
        }


        protected override string GetId(UnitTermData d) => $"{d.MasterId}.{d.TermId}";


        protected override UnitTerm GetObject(UnitTermData d) => new UnitTerm(d);


        protected override void SetId(UnitTermData d, string id)
        {

            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);
            d.MasterId = masterId;
            d.TermId = termId;

        }

    }
    
}
