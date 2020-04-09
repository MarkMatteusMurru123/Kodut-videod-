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
    public class MeasuresPageTests : AbstractClassTests<MeasuresPage, CommonPage<IMeasuresRepository, Measure, MeasureView, MeasureData>>
    {
        private class TestClass : MeasuresPage
        {
            internal TestClass(IMeasuresRepository r, IMeasureTermsRepository t) : base(r, t) { }
            
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<Measure, MeasureData>, IMeasuresRepository
        {
            
        }
        private class TermRepository : BaseTestRepositoryForPeriodEntity<MeasureTerm, MeasureTermData>,IMeasureTermsRepository
        {

            protected override bool IsThis(MeasureTerm entity, string id)
            {
                return true;
            }

            protected override string GetId(MeasureTerm entity)
            {
                return string.Empty;
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new TestRepository();
            var t = new TermRepository();
            Obj = new TestClass(r, t); //???
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<MeasureView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }
        [TestMethod]
        public void PageTitleTest()=>Assert.AreEqual("Measures",Obj.PageTitle);
        [TestMethod]
        public void PageUrlTest()=>Assert.AreEqual("/Quantity/Measures", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<MeasureView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }
        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<MeasureData>();
            var view = Obj.ToView(new Measure(data));
            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void LoadDetailsTest()
        {
            var v = GetRandom.Object<MeasureView>();
            Obj.LoadDetails(v);
            Assert.IsNotNull(Obj.Terms);
        }
        [TestMethod]
        public void TermsTest()
        {
            IsReadOnlyProperty(Obj,nameof(Obj.Terms), Obj.Terms);
        }
    }

    
}
