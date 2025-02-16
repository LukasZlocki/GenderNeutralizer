using GenderNeutralizer.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GenderNeutralizer.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
