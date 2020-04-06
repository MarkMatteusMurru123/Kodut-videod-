using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abc.Aids;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureData = Abc.Data.Quantity.MeasureData;

namespace Abc.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<Measure, MeasureData>, BaseRepository<Measure, MeasureData>>
    {
        private class TestClass : SortedRepository<Measure, MeasureData>
        {
            public TestClass(DbContext c, DbSet<MeasureData> s) : base(c, s)
            {
            }

            protected internal override Measure ToDomainObject(MeasureData d) => new Measure(d);
            

            protected override async Task<MeasureData> GetData(string id)
            {
                await Task.CompletedTask;
                return new MeasureData();
            }

            protected override string GetId(Measure entity) => entity?.Data?.Id;



        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options; //nuud on andmebaas kaasas, saab teha intergratsioonitestid
            var c = new QuantityDbContext(options);
            Obj = new TestClass(c, c.Measures);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            IsNullableProperty(() => Obj.SortOrder, x => Obj.SortOrder=x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<TestClass>(x => x.DescendingString);
            IsReadOnlyProperty(Obj, propertyName, "_desc");
        }

        

        [TestMethod]
        public void SetSortingTest()
        {
            void Test(IQueryable<MeasureData> d,string sortOrder)
            {
                Obj.SortOrder = sortOrder + Obj.DescendingString;
                var set = Obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"Abc.Data.Quantity.MeasureData]).OrderByDescending(x => Convert(x.{sortOrder}, Object))"));
                Obj.SortOrder = sortOrder;
                set = Obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.Contains($"Abc.Data.Quantity.MeasureData]).OrderBy(x => Convert(x.{sortOrder}, Object))"));
            }

            Assert.IsNull(Obj.AddSorting(null));
            IQueryable<MeasureData> data = Obj.DbSet;
            Obj.SortOrder = null;
            Assert.AreEqual(data, Obj.AddSorting(data));
            Test(data, GetMember.Name<MeasureData>(x => x.Id));
            Test(data, GetMember.Name<MeasureData>(x => x.Code));
            Test(data, GetMember.Name<MeasureData>(x => x.Name));
            Test(data, GetMember.Name<MeasureData>(x => x.Definition));
            Test(data, GetMember.Name<MeasureData>(x => x.ValidFrom));
            Test(data, GetMember.Name<MeasureData>(x => x.ValidTo));
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            TestCreateExpression(GetMember.Name<MeasureData>(x => x.ValidFrom));
            TestCreateExpression(GetMember.Name<MeasureData>(x => x.ValidTo));
            TestCreateExpression(GetMember.Name<MeasureData>(x => x.Name));
            TestCreateExpression(GetMember.Name<MeasureData>(x => x.Definition));
            TestCreateExpression(GetMember.Name<MeasureData>(x => x.Code));
            TestCreateExpression(GetMember.Name<MeasureData>(x => x.Id));
            TestCreateExpression(s = GetMember.Name<MeasureData>(x => x.ValidFrom), s + Obj.DescendingString);
            TestCreateExpression(s= GetMember.Name<MeasureData>(x => x.ValidTo),s + Obj.DescendingString);
            TestCreateExpression(s=GetMember.Name<MeasureData>(x => x.Name),s + Obj.DescendingString);
            TestCreateExpression(s=GetMember.Name<MeasureData>(x => x.Definition),s + Obj.DescendingString);
            TestCreateExpression(s=GetMember.Name<MeasureData>(x => x.Code),s + Obj.DescendingString);
            TestCreateExpression(s=GetMember.Name<MeasureData>(x => x.Id),s + Obj.DescendingString);

            TestNullExpression(GetRandom.String());
            TestNullExpression(string.Empty);
            TestNullExpression(null);

        }

        private void TestNullExpression(string name)
        {
            Obj.SortOrder = name;
            var lambda = Obj.CreateExpression();
            Assert.IsNull(lambda);
        }

        private void TestCreateExpression(string expected, string name = null)
        {
            name ??= expected;
            Obj.SortOrder = name;
            var lambda = Obj.CreateExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<System.Func<MeasureData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));

        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<MeasureData>(x => x.ValidFrom);
            var property = typeof(MeasureData).GetProperty(name);
            var lambda = Obj.LambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<System.Func<MeasureData,object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;
            void Test(PropertyInfo expected, string sortOrder)
            {
                Obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, Obj.FindProperty());
            }
            Test(null, GetRandom.String());
            Test(null, null);
            Test(null, string.Empty);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)),s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s + Obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s + Obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s + Obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s + Obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s + Obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s + Obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;

            void Test(string expected, string sortOrder)
            {
                Obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, Obj.GetName());
            }

            Test(s = GetRandom.String(), s);
            Test(s = GetRandom.String(), s + Obj.DescendingString);
            Test(string.Empty, string.Empty);
            Test(string.Empty, null);

        }

        [TestMethod]
        public void SetOrderByTest()
        {
            void Test(IQueryable<MeasureData> d, Expression<Func<MeasureData, object>> e, string expected)
            {
                Obj.SortOrder = GetRandom.String() + Obj.DescendingString;
                var set = Obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"Abc.Data.Quantity.MeasureData]).OrderByDescending({expected})"));
                Obj.SortOrder = GetRandom.String();
                set = Obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString().Contains($"Abc.Data.Quantity.MeasureData]).OrderBy({expected})"));
            }

            Assert.IsNull(Obj.AddOrderBy(null, null));
            IQueryable<MeasureData> data = Obj.DbSet;
            Assert.AreEqual(data, Obj.AddOrderBy(data, null));
            Test(data, x => x.Id, "x => x.Id");
            Test(data, x => x.Code, "x => x.Code");
            Test(data, x => x.Name, "x => x.Name");
            Test(data, x => x.Definition, "x => x.Definition");
            Test(data, x => x.ValidFrom, "x => Convert(x.ValidFrom, Object");
            Test(data, x => x.ValidTo, "x => Convert(x.ValidTo, Object)");

        }
        [TestMethod]
        public void IsDescendingTest()
        {
            void Test(string sortOrder, bool expected)
            {
                Obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, Obj.IsDescending());
            }

            Test(GetRandom.String(), false);
            Test(GetRandom.String() + Obj.DescendingString, true);
            Test(string.Empty, false);
            Test(null, false);
        }
    }

}
