using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DreamsAI.Models;

namespace DreamsAI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SleepSession> SleepSessions { get; set; }
        public DbSet<Dream> Dream { get; set; }
        public DbSet<DreamsAI.Models.User> User { get; set; } = default!;
    }
}
