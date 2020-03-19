﻿using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Units
{
    public class IndexModel : UnitsPage
    {
    
        public IndexModel(IUnitsRepository r, IMeasuresRepository m) : base(r,m)
        {
        }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            await GetList(sortOrder,
                currentFilter, searchString, pageIndex);
           

        }

       
    }
}
