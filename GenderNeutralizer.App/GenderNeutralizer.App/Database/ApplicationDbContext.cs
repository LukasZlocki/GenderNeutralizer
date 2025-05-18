using GenderNeutralizer.App.Models;
using Microsoft.EntityFrameworkCore;

namespace GenderNeutralizer.App.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }


    }
}
