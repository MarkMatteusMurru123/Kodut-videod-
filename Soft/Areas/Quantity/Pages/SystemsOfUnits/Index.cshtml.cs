﻿using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.SystemsOfUnits
{
    public class IndexModel : SystemsOfUnitsPage
    {
    
        public IndexModel(ISystemsOfUnitsRepository r) : base(r)
        {
        }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder,
                currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }

    }
}
