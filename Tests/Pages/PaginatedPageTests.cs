using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages {

    [TestClass] public class PaginatedPageTests : AbstractPageTests<
        PaginatedPage<IMeasuresRepository, Measure, MeasureView, MeasureData>,
        CrudPage<IMeasuresRepository, Measure, MeasureView, MeasureData>> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            Obj = new TestClass(Db);
        }

        [TestMethod] public void ItemsTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.Items), null);
        }

        [TestMethod] public void PageIndexTest() {
            var i = GetRandom.UInt8(3);
            Obj.PageIndex = i;
            Assert.AreEqual(i, Db.PageIndex);
            Assert.AreEqual(i, Obj.PageIndex);
        }

        [TestMethod] public void HasPreviousPageTest() {
            Db.HasPreviousPage = GetRandom.Bool();
            IsReadOnlyProperty(Obj, nameof(Obj.HasPreviousPage), Db.HasPreviousPage);
        }

        [TestMethod] public void HasNextPageTest() {
            Db.HasNextPage = GetRandom.Bool();
            IsReadOnlyProperty(Obj, nameof(Obj.HasNextPage), Db.HasNextPage);
        }

        [TestMethod] public void TotalPagesTest() {
            Db.TotalPages = GetRandom.UInt8();
            IsReadOnlyProperty(Obj, nameof(Obj.TotalPages), Db.TotalPages);
        }

        [TestMethod] public void GetListTest() {
            Assert.IsNull(Obj.Items);
            var sortOrder = GetRandom.String();
            var currentFilter = GetRandom.String();
            var searchString = GetRandom.String();
            var fixedFilter = GetRandom.String();
            var fixedValue = GetRandom.String();
            var pageIndex = GetRandom.UInt8();
            Obj.GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            Assert.IsNotNull(Obj.Items);
            Assert.AreEqual(sortOrder, Obj.SortOrder);
            Assert.AreEqual(searchString, Obj.SearchString);
            Assert.AreEqual(fixedFilter, Obj.FixedFilter);
            Assert.AreEqual(fixedValue, Obj.FixedValue);
            Assert.AreEqual(1, Obj.PageIndex);
        }

        [TestMethod] public void GetListNoArgumentsTest() {
            var l = Obj.GetList().GetAwaiter().GetResult();
            Assert.AreEqual(0, l.Count);

            for (var i = 0; i < GetRandom.UInt8(); i++) {
                var d = GetRandom.Object<MeasureData>();
                Db.Add(new Measure(d)).GetAwaiter();
                l = Obj.GetList().GetAwaiter().GetResult();
                Assert.AreEqual(i + 1, l.Count);
            }
        }

    }

}
