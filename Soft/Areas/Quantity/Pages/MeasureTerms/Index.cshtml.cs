﻿using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.MeasureTerms
{
    public class IndexModel : MeasureTermsPage
    {
    
        public IndexModel(IMeasureTermsRepository r, IMeasuresRepository m) : base(r, m)
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
