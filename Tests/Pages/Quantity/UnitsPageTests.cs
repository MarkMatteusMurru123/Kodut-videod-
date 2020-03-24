﻿using System.Linq;
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
        private UnitsRepository _units;
        private MeasuresRepository _measures;
        private MeasureData _data;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _units = new UnitsRepository();
            _measures = new MeasuresRepository();
            _data = GetRandom.Object<MeasureData>();
            var m = new Measure(_data);
            _measures.Add(m).GetAwaiter();
            AddRandomMeasures();
            obj = new TestClass(_units, _measures);
        }

        private void AddRandomMeasures()
        {
            for(var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<MeasureData>();
                var m = new Measure(d);
                _measures.Add(m).GetAwaiter();
            }
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
            var d = GetRandom.Object<UnitData>();
            var view = obj.ToView(new Unit(d));
            TestArePropertyValuesEqual(view, d);

        }
        [TestMethod]
        public void GetMeasureNameTest()
        {
            var name = obj.GetMeasureName(_data.ID);
            Assert.AreEqual(_data.Name, name);
        }
        [TestMethod]
        public void MeasuresTest()
        {
            var list = _measures.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Measures.Count());
        }
    }
   
}
