using GenderNeutralizer.App.Models;

namespace GenderNeutralizer.App.Services
{
    public interface ITextExtractionService
    {
        public string ExtractTextFromFile(string filePath);
    }
}
