using System;
using System.Linq;
using System.Linq.Expressions;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra.Quantity {

    [TestClass] public class QuantityDbContextTests : BaseClassTests<QuantityDbContext, DbContext> {

        private DbContextOptions<QuantityDbContext> _options;

        private class TestClass : QuantityDbContext {

            public TestClass(DbContextOptions<QuantityDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating() {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }

        }


        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            _options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            Obj = new QuantityDbContext(_options);
        }

        [TestMethod] public void InitializeTablesTest() {
            static void TestKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values) {
                var key = entity.FindPrimaryKey();

                if (values is null) Assert.IsNull(key);
                else
                    foreach (var v in values) {
                        var name = GetMember.Name(v);
                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
                    }
            }

            static void TestEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values) {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                TestKey(entity, values);
            }

            QuantityDbContext.InitializeTables(null);
            var o = new TestClass(_options);
            var builder = o.RunOnModelCreating();
            QuantityDbContext.InitializeTables(builder);
            TestEntity<SystemOfUnitsData>(builder);
            TestEntity<MeasureTermData>(builder, x => x.TermId, x => x.MasterId);
            TestEntity<MeasureData>(builder);
            TestEntity<UnitData>(builder);
            TestEntity<UnitTermData>(builder, x => x.TermId, x => x.MasterId);
            TestEntity<UnitFactorData>(builder, x =>x.UnitId, x=> x.SystemOfUnitsId);
        }

        [TestMethod]
        public void MeasuresTest() =>
            IsNullableProperty(Obj, nameof(Obj.Measures), typeof(DbSet<MeasureData>));

        [TestMethod] public void UnitsTest() => IsNullableProperty(Obj, nameof(Obj.Units), typeof(DbSet<UnitData>));

        [TestMethod]
        public void SystemsOfUnitsTest() =>
            IsNullableProperty(Obj, nameof(Obj.SystemsOfUnits), typeof(DbSet<SystemOfUnitsData>));

        [TestMethod]
        public void UnitFactorsTest() =>
            IsNullableProperty(Obj, nameof(Obj.UnitFactors), typeof(DbSet<UnitFactorData>));

        [TestMethod]
        public void UnitTermsTest() =>
            IsNullableProperty(Obj, nameof(Obj.UnitTerms), typeof(DbSet<UnitTermData>));

        [TestMethod]
        public void MeasureTermsTest() =>
            IsNullableProperty(Obj, nameof(Obj.MeasureTerms), typeof(DbSet<MeasureTermData>));

    }

}
