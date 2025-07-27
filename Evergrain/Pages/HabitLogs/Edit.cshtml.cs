using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evergrain.Data;

namespace Evergrain.Pages.HabitLogs
{
    public class EditModel : PageModel
    {
        private readonly Evergrain.Data.ApplicationDbContext _context;

        public EditModel(Evergrain.Data.ApplicationDbContext context)
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

            var habitlog =  await _context.HabitLogs.FirstOrDefaultAsync(m => m.Id == id);
            if (habitlog == null)
            {
                return NotFound();
            }
            habitLog = habitlog;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(habitLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!habitLogExists(habitLog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool habitLogExists(Guid id)
        {
            return _context.HabitLogs.Any(e => e.Id == id);
        }
    }
}
