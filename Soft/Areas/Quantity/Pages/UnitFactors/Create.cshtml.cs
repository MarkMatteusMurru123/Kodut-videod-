using System.Collections.Generic;
using System.Threading.Tasks;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Soft.Areas.Quantity.Pages.UnitFactors
{
    public class CreateModel : UnitFactorsPage
    {
        public CreateModel(IUnitFactorsRepository r, IUnitsRepository u, ISystemsOfUnitsRepository s) : base(r)
        {
            Units = CreateSelectList<Unit, UnitData>(u);
            SystemsOfUnits = CreateSelectList<SystemOfUnits, SystemOfUnitsData>(s);

        }
        public IEnumerable<SelectListItem> SystemsOfUnits { get; }
        public IEnumerable<SelectListItem> Units { get; }

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {

            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await AddObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }

        
    }
}
    

        
    

