﻿using Abc.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitTermViewTests : SealedClassTests<UnitTermView, CommonTermView>
    {
        [TestMethod] public void MasterIdTest() => IsNullableProperty(() => Obj.MasterId, x => Obj.MasterId = x);
    }
}