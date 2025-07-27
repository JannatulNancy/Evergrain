using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Evergrain.Data;

namespace Evergrain.Pages.Models
{
    public class DetailsModel : PageModel
    {
        private readonly Evergrain.Data.ApplicationDbContext _context;

        public DetailsModel(Evergrain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Habit Habit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habit = await _context.Habits.FirstOrDefaultAsync(m => m.Id == id);

            if (habit is not null)
            {
                Habit = habit;

                return Page();
            }

            return NotFound();
        }
    }
}
