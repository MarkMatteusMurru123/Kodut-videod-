using System;
using System.Collections.Generic;
using System.Text;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Abc.Pages.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Quantity
{
    [TestClass]
    public class UnitsPageTests : AbstractClassTests<UnitsPage, BasePage<IUnitsRepository, Unit, UnitView, UnitData>>
    {
        private class TestClass : UnitsPage
        {
            internal TestClass(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }
        }

        private class UnitsRepository : BaseTestRepository<Unit,UnitData>, IUnitsRepository
        {

        }
        private class MeasuresRepository : BaseTestRepository<Measure, MeasureData>, IMeasuresRepository
        {

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var u = new UnitsRepository();
            var m = new MeasuresRepository();
            obj = new TestClass(u, m);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<UnitView>();
            obj.Item = item;
            Assert.AreEqual(item.ID, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }
        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Units", obj.PageTitle);
        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Quantity/Units", obj.PageURL);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }
        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<UnitData>();
            var view = obj.ToView(new Unit(data));
            TestArePropertyValuesEqual(view, data);

        }

    }
   
}
