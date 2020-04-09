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
            internal TestClass(IMeasuresRepository r) : base(r) { }
            
        }

        private class TestRepository : BaseTestRepository<Measure, MeasureData>, IMeasuresRepository
        {

        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new TestRepository();
            Obj = new TestClass(r);
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

    }
}
