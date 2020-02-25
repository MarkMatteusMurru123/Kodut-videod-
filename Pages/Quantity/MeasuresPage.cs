﻿using System.Collections.Generic;
using Abc.Domain.Quantity;
using Facade.Quantity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abc.Pages.Quantity
{
    public abstract class MeasuresPage : PageModel
    {
        protected internal readonly IMeasuresRepository Data;

        protected internal MeasuresPage(IMeasuresRepository r)
        {
            Data = r;
        }
        [BindProperty]
        public MeasureView Item { get; set; }
        public IList<MeasureView> Items { get; set; }
    }
}