using System.Collections.Generic;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{
    public class MeasureTermsPage : CommonPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData>
    {
        protected internal MeasureTermsPage(IMeasureTermsRepository r, IMeasuresRepository m) : base(r)
        {
            PageTitle = "Measure Terms";
            Measures = CreateSelectList<Measure, MeasureData>(m);
        }
        public IEnumerable<SelectListItem> Measures { get; }

        public override string ItemId
        {
            get
            {
                if (Item is null) return string.Empty;
                return $"{Item.MasterId}.{Item.TermId}";
            }
        }
        protected internal override string GetPageUrl() => "/Quantity/MeasureTerms";
        protected internal override MeasureTerm ToObject(MeasureTermView view)
        {
            return MeasureTermViewFactory.Create(view);
        }

        protected internal override MeasureTermView ToView(MeasureTerm obj)
        {
            return MeasureTermViewFactory.Create(obj);
        }

        public string GetMeasureName(string measureId)
        {
            foreach(var m in Measures)
                if (m.Value == measureId)
                    return m.Text;
            return "Unspecified";

        }
        protected internal override  string GetPageSubTitle()
        {
            return FixedValue is null ? base.GetPageSubTitle() : $"For{GetMeasureName(FixedValue)}";
        }
    } 
    
}
