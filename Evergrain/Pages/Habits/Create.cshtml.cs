﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Evergrain.Data;

namespace Evergrain.Pages.Models
{
    public class CreateModel : PageModel
    {
        private readonly Evergrain.Data.ApplicationDbContext _context;

        public CreateModel(Evergrain.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Habit Habit { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Habits.Add(Habit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
