using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages {

    [TestClass]
    public class CommonPageTests
        : AbstractPageTests<CommonPage<IMeasuresRepository, Measure, MeasureView, MeasureData>
            , PaginatedPage<IMeasuresRepository, Measure, MeasureView, MeasureData>> {
       
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass(new TestRepository());
        }

        [TestMethod] public void ItemIdTest() {
            Obj.Item = GetRandom.Object<MeasureView>();
            Assert.AreEqual(Obj.Item.Id, Obj.ItemId);
        }

        [TestMethod] public void PageTitleTest() {
            IsNullableProperty(()=> Obj.PageTitle, x => Obj.PageTitle = x);
        }

        [TestMethod] public void PageSubTitleTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.PageSubTitle), Obj.GetPageSubTitle());
        }

        [TestMethod] public void GetPageSubtitleTest() {
            Assert.AreEqual(Obj.PageSubTitle, Obj.GetPageSubTitle());
        }

        [TestMethod] public void PageUrlTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.PageUrl), Obj.GetPageUrl());
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(Obj.PageUrl, Obj.GetPageUrl());
        }

        [TestMethod] public void IndexUrlTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.IndexUrl), Obj.GetIndexUrl());
        }

        [TestMethod] public void GetIndexUrlTest() {
            Assert.AreEqual(Obj.IndexUrl, Obj.GetIndexUrl());
        }

    }

}
