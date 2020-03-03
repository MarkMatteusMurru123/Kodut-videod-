﻿using System;
using System.Collections.Generic;
using System.Text;
using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Quantity
{
    [TestClass]
    public class UnitDataTests : SealedClassTest<UnitData, DefinedEntityData>
    {
        [TestMethod]
        public void MeasureIDTest()
        {
            isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);
        }
    }
}
