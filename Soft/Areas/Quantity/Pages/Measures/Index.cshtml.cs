using System.Collections.Generic;
using System.Threading.Tasks;
using Facade.Quantity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public IndexModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MeasureView> MeasureView { get;set; }

        public async Task OnGetAsync()
        {
            MeasureView = await _context.Measures.ToListAsync();
        }
    }
}
