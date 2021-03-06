﻿using System.Collections.Generic;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{
    public class UnitTermsPage : CommonPage<IUnitTermsRepository, UnitTerm, UnitTermView, UnitTermData>
    {
        protected internal UnitTermsPage(IUnitTermsRepository r, IUnitsRepository u) : base(r)
        {
            PageTitle = "Unit Terms";
            Units = CreateSelectList<Unit, UnitData>(u);
        }
        public IEnumerable<SelectListItem> Units { get; }
        public override string ItemId => Item is null ? string.Empty : $"{Item.MasterId}.{Item.TermId}";
        protected internal override string GetPageUrl() => "/Quantity/UnitTerms";
        protected internal override UnitTerm ToObject(UnitTermView view)
        {
            return UnitTermViewFactory.Create(view);
        }

        protected internal override UnitTermView ToView(UnitTerm obj)
        {
            return UnitTermViewFactory.Create(obj);
        }
    
    }
}
