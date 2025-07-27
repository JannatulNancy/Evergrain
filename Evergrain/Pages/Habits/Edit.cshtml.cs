using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evergrain.Data;

namespace Evergrain.Pages.Models
{
    public class EditModel : PageModel
    {
        private readonly Evergrain.Data.ApplicationDbContext _context;

        public EditModel(Evergrain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Habit Habit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habit =  await _context.Habits.FirstOrDefaultAsync(m => m.Id == id);
            if (habit == null)
            {
                return NotFound();
            }
            Habit = habit;
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

            _context.Attach(Habit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitExists(Habit.Id))
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

        private bool HabitExists(int id)
        {
            return _context.Habits.Any(e => e.Id == id);
        }
    }
}
