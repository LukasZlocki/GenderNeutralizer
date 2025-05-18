using GenderNeutralizer.App.Models;

namespace GenderNeutralizer.App.Services
{
    public interface ITextExtractionService
    {
        public Task<bool> NeutralizeCandidateCv(string filePath, int candidateId);
    }
}
