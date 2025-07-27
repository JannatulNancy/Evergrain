using Evergrain.Pages.HabitLogs;
using Evergrain.Pages.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Generic;

namespace Evergrain.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<Habit> Habits { get; set; }
        public DbSet<habitLog> HabitLogs { get; set; }
    }
}
