using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages {

    [TestClass]
    public class BasePageTests : AbstractPageTests<BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>,
        PageModel> {


        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            Obj = new TestClass(Db);
        }

        [TestMethod] public void FixedValueTest() {
            var s = GetRandom.String();
            Obj.FixedValue = s;
            Assert.AreEqual(s, Db.FixedValue);
            Assert.AreEqual(s, Obj.FixedValue);
        }

        [TestMethod] public void FixedFilterTest() {
            var s = GetRandom.String();
            Obj.FixedFilter = s;
            Assert.AreEqual(s, Db.FixedFilter);
            Assert.AreEqual(s, Obj.FixedFilter);
        }

        [TestMethod] public void SetFixedFilterTest() {
            var filter = GetRandom.String();
            var value = GetRandom.String();
            Obj.setFixedFilter(filter, value);
            Assert.AreEqual(filter, Obj.FixedFilter);
            Assert.AreEqual(value, Obj.FixedValue);
        }

        [TestMethod] public void SortOrderTest() {
            var s = GetRandom.String();
            Obj.SortOrder = s;
            Assert.AreEqual(s, Db.SortOrder);
            Assert.AreEqual(s, Obj.SortOrder);
        }

        [TestMethod] public void GetSortOrderTest() {
            void test(string sortOrder, string name, bool isDesc) {
                Obj.SortOrder = sortOrder;
                var actual = Obj.getSortOrder(name);
                var expected = isDesc ? name + "_desc" : name;
                Assert.AreEqual(expected, actual);
            }
            test(null, GetRandom.String(), false);
            test(GetRandom.String(), GetRandom.String(), false);
            var s = GetRandom.String();
            test(s, s, true);
            test(s+"_desc", s, false);
        }

        [TestMethod] public void SearchStringTest() {
            var s = GetRandom.String();
            Obj.SearchString = s;
            Assert.AreEqual(s, Db.SearchString);
            Assert.AreEqual(s, Obj.SearchString);
        }

        [TestMethod] public void GetSortStringTest() {
            const string page = "xxx/yyy";
            Obj.SortOrder = "Code";
            Obj.SearchString = "AAA";
            Obj.FixedFilter = "BBB";
            Obj.FixedValue = "CCC";
            var sortString = Obj.GetSortString(x=>x.Code, page);
            var s = "xxx/yyy?sortOrder=Code_desc&currentFilter=AAA&fixedFilter=BBB&fixedValue=CCC";
            Assert.AreEqual(s, sortString);
        }

        [TestMethod] public void GetSearchStringTest() {
            void test(string filter, string searchString, int? pageIndex, bool isFirst) {
                var expectedSearchString = isFirst ? searchString: filter;
                var expectedIndex = isFirst ? 1 : pageIndex;
                var actual = BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>.getSearchString(filter, searchString, ref pageIndex);
                Assert.AreEqual(expectedSearchString, actual);
                Assert.AreEqual(expectedIndex, pageIndex);
            }
            test(GetRandom.String(), GetRandom.String(), GetRandom.UInt8(3), true);
            test(GetRandom.String(), null, GetRandom.UInt8(3), false);
        }


    }

}
