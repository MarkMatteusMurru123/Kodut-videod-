using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
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
    public class SortedRepositoryTests : AbstractClassTest<SortedRepository<Measure, MeasureData>, BaseRepository<Measure, MeasureData>>
    {
        private class tesClass : SortedRepository<Measure, MeasureData>
        {
            public tesClass(DbContext c, DbSet<MeasureData> s) : base(c, s)
            {
            }

            protected override Task<MeasureData> GetData(string id)
            {
                throw new NotImplementedException();
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var c = new QuantityDbcontext(new DbContextOptions<QuantityDbcontext>());
            obj = new tesClass(c,c.Measures);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            isNullableProperty(() => obj.SortOrder, x => obj.SortOrder=x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<tesClass>(x => x.DescendingString);
            IsReadOnlyProperty(obj, propertyName, "_desc");
        }

        

        [TestMethod]
        public void SetSortingTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<MeasureData>(x => x.ValidFrom);
            var property = typeof(MeasureData).GetProperty(name);
            var lambda = obj.LambdaExpression(property);
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
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.FindProperty());
            }
            Test(null, GetRandom.String());
            Test(null, null);
            Test(null, string.Empty);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)),s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ID)), s);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s + obj.DescendingString);
            Test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ID)), s + obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;

            void Test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.GetName());
            }

            Test(s = GetRandom.String(), s);
            Test(s = GetRandom.String(), s + obj.DescendingString);
            Test(string.Empty, string.Empty);
            Test(string.Empty, null);

        }

        [TestMethod]
        public void IsDescendingTest()
        {
            void Test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.IsDescending());
            }

            Test(GetRandom.String(), false);
            Test(GetRandom.String() + obj.DescendingString, true);
            Test(string.Empty, false);
            Test(null, false);
        }
    }

}
