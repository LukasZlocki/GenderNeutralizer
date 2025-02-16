using GenderNeutralizer.Api.Context;
using GenderNeutralizer.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GenderNeutralizer.Api.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly AppDbContext _db;
        private readonly ILogger _logger;

        public CandidateService(AppDbContext db, ILogger logger)
        {
            _db = db;
            _logger = logger;
        }


        public async Task AddCandidate(Candidate candidate)
        {
            try
            {
                _db.Candidates.Add(candidate);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Candadate created with ID {CandidateId}", candidate.CandidateId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error accured during creating new candidate");
                throw;
            }
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            var candidates = await _db.Candidates.ToListAsync();
            return candidates;
        }

        public Task<Candidate> GetCandidateById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
