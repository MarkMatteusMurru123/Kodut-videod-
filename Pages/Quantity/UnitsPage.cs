using System.Collections.Generic;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Quantity
{
    public abstract class UnitsPage : BasePage<IUnitsRepository, Unit, UnitView, UnitData>
    {
        protected internal UnitsPage(IUnitsRepository r, IMeasuresRepository m) : base(r)
        {
            PageTitle = "Units";
            Measures = CreateMeasures(m);
        }

        private static IEnumerable<SelectListItem> CreateMeasures(IMeasuresRepository r)
        {
            var list = new List<SelectListItem>(0);
            var measures = r.Get().GetAwaiter().GetResult();
            foreach (var m in measures) 
            {
               list.Add(new SelectListItem(m.Data.Name, m.Data.ID)); 
            }
            return list;

        }

        public IEnumerable<SelectListItem> Measures { get; }


        public override string ItemId => Item.ID;

        protected internal override string GetPageURL() => "/Quantity/Units";



        protected internal override string GetPageSubtitle()
        {
            return FixedValue is null ? base.GetPageSubtitle() : $"For {GetMeasureName(FixedValue)}";
        }
        protected internal override Unit ToObject(UnitView view)
        {
            return UnitViewFactory.Create(view);
        }

        protected internal override UnitView ToView(Unit obj)
        {
            return UnitViewFactory.Create(obj);
        }
        public string GetMeasureName(string measureId)
        {
            
            foreach (var m in Measures)
            {
                if (m.Value == measureId) 
                    return m.Text;
            }
            return "Unspecified";
            throw new System.NotImplementedException();
        }
    }
}
