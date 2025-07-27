using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Evergrain.Data;

namespace Evergrain.Pages.HabitLogs
{
    public class DeleteModel : PageModel
    {
        private readonly Evergrain.Data.ApplicationDbContext _context;

        public DeleteModel(Evergrain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public habitLog habitLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitlog = await _context.HabitLogs.FirstOrDefaultAsync(m => m.Id == id);

            if (habitlog is not null)
            {
                habitLog = habitlog;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitlog = await _context.HabitLogs.FindAsync(id);
            if (habitlog != null)
            {
                habitLog = habitlog;
                _context.HabitLogs.Remove(habitLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
