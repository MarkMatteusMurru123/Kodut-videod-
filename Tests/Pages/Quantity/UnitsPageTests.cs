using System.Linq;
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
    public class UnitsPageTests : AbstractClassTests<UnitsPage, CommonPage<IUnitsRepository, Unit, UnitView, UnitData>>
    {
        private class TestClass : UnitsPage
        {
            internal TestClass(IUnitsRepository r, IMeasuresRepository m, IUnitTermsRepository t, IUnitFactorsRepository f) : base(r, m, t, f) { }
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
            Obj = new TestClass(_units, _measures);
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
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }
        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Units", Obj.PageTitle);
        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Quantity/Units", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }
        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<UnitData>();
            var view = Obj.ToView(new Unit(d));
            TestArePropertyValuesEqual(view, d);

        }
        [TestMethod]
        public void GetMeasureNameTest()
        {
            var name = Obj.GetMeasureName(_data.Id);
            Assert.AreEqual(_data.Name, name);
        }
        [TestMethod]
        public void MeasuresTest()
        {
            var list = _measures.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, Obj.Measures.Count());
        }
    }
   
}
