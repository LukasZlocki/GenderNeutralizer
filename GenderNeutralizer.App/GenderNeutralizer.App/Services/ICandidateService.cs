using GenderNeutralizer.App.Models;

namespace GenderNeutralizer.App.Services
{
    public interface ICandidateService
    {
        public Task<bool> AddCandidateAsync(Candidate candidate);
        public Task<List<Candidate>> GetAllCandidatesAsync();
        Task<bool> UpdateCandidateAsync(Candidate candidate);
    }
}
