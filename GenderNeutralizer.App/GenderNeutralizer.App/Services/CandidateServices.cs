using GenderNeutralizer.App.Database;
using GenderNeutralizer.App.Models;

namespace GenderNeutralizer.App.Services
{
    public class CandidateServices : ICandidateService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<CandidateServices> _logger;

        public CandidateServices(ApplicationDbContext db, ILogger<CandidateServices> logger)
        {
            _db = db;
            _logger = logger;
        }


       
        public async Task<bool> AddCandidateAsync(Candidate candidate)
        {
            try
            {
                await _db.Candidates.AddAsync(candidate);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the error if needed: Console.WriteLine(ex.Message);
                _logger.LogError(ex, "Error adding candidate to the database.");
                return false;
            }
        }
    }
}
