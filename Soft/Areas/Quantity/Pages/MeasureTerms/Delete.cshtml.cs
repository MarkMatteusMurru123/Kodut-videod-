﻿using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;

namespace Soft.Areas.Quantity.Pages.MeasureTerms
{
    public class DeleteModel : MeasureTermsPage
    {

        public DeleteModel(IMeasureTermsRepository r, IMeasuresRepository m) : base(r, m)
        {

        }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            await DeleteObject(id, fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }



    }
}
