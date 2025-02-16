using GenderNeutralizer.Api.Models;

namespace GenderNeutralizer.Api.Services
{
    public interface ICandidateService
    {
        public Task AddCandidate(Candidate candidate);
        public Task<Candidate> GetCandidateById(Guid id);
    }
}
