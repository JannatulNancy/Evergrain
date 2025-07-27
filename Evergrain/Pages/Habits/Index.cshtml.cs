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
    public class IndexModel : PageModel
    {
        private readonly Evergrain.Data.ApplicationDbContext _context;

        public IndexModel(Evergrain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Habit> Habit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Habit = await _context.Habits.ToListAsync();
        }
    }
}
