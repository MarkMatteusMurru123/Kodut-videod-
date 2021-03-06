﻿using System;
using System.Collections.Generic;
using System.Text;
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
    public class UnitFactorsRepositoryTests : RepositoryTests<UnitFactorsRepository, UnitFactor, UnitFactorData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            Db = new QuantityDbContext(options);
            DbSet = ((QuantityDbContext)Db).UnitFactors;
            Obj = new UnitFactorsRepository((QuantityDbContext)Db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(PaginatedRepository<UnitFactor, UnitFactorData>);
        }


        protected override string GetId(UnitFactorData d) => $"{d.SystemOfUnitsId}.{d.UnitId}"; 


        protected override UnitFactor GetObject(UnitFactorData d) => new UnitFactor(d);


        protected override void SetId(UnitFactorData d, string id)
        {

            var systemOfUnitsId = GetString.Head(id);
            var unitId = GetString.Tail(id);
            d.SystemOfUnitsId = systemOfUnitsId;
            d.UnitId = unitId;

        }

    }
    
}
