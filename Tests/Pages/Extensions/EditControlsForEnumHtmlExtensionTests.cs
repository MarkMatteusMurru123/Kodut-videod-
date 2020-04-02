﻿using System;
using System.Collections.Generic;
using Abc.Core;
using Abc.Facade.Common;
using Abc.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Extensions {

    [TestClass]
    public class EditControlsForEnumHtmlExtensionTests : BaseTests
    {
        private class TestClass : NamedView
        {
            public IsoGender Gender { get; set; }
        }

        [TestInitialize] public virtual void TestInitialize() => Type = typeof(EditControlsForEnumHtmlExtension);

        [TestMethod]
        public void EditControlsForEnumTest()
        {
            var obj = new HtmlHelperMock<TestClass>().EditControlsForEnum(x => x.Gender);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var selectList = new SelectList(Enum.GetNames(typeof(IsoGender)));
            var expected = new List<string> { "<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>" };
            var actual = EditControlsForEnumHtmlExtension.HtmlStrings(new HtmlHelperMock<TestClass>(), 
                x => x.Gender, selectList);
            TestHtml.Strings(actual, expected);
        }


    }

}