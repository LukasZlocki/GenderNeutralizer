using GenderNeutralizer.App.Database;
using GenderNeutralizer.App.Models;
using Microsoft.EntityFrameworkCore;

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


        /// <summary>
        /// Adds a new candidate to the database.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
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

        public async Task<bool> DeleteCandidateAsync(int candidateId)
        {
            var candidate = await _db.Candidates.FindAsync(candidateId);

            if (candidate == null)
                return false;

            _db.Candidates.Remove(candidate);
            await _db.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Retrieves all candidates from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Candidate>> GetAllCandidatesAsync()
        {
            try
            {
                return await _db.Candidates
                    .Where(b => b.isCvNeutralized == false)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving candidates");
                return new List<Candidate>();
            }
        }

        public async Task<List<Candidate>> GetAllCandidatesToMeetAsync()
        {
            try
            {
                return await _db.Candidates
                    .Where(b => b.IsCandidateToMeet == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving candidates");
                return new List<Candidate>();
            }
        }

        public async Task<List<Candidate>> GetAllNeutralizedCandidatesAsync()
        {
            try
            {
                return await _db.Candidates
                    .Where(b => b.isCvNeutralized == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving candidates");
                return new List<Candidate>();
            }
        }

        public async Task<bool> UpdateCandidateAcceptedToMeet(int candidateId)
        {
            try
            {
                var existingCandidate = await _db.Candidates.FindAsync(candidateId);
                if (existingCandidate == null)
                {
                    _logger.LogWarning("Candidate with ID {Id} not found.", candidateId);
                    return false;
                }

                // Update status to ready to meet
                existingCandidate.isCvNeutralized = false;
                existingCandidate.IsCandidateToMeet = true;

                await _db.SaveChangesAsync();
                _logger.LogInformation("Candidate with ID {Id} updated.", candidateId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating candidate with ID {Id}", candidateId);
                return false;
            }
        }

        /// <summary>
        /// Updates an existing candidate in the database.
        /// </summary>
        /// <param name="candidate">Object Candidate</param>
        /// <returns>bolean</returns>
        public async Task<bool> UpdateCandidateAsync(Candidate candidate)
        {
            try
            {
                var existingCandidate = await _db.Candidates.FindAsync(candidate.CandidateId);
                if (existingCandidate == null)
                {
                    _logger.LogWarning("Candidate with ID {Id} not found.", candidate.CandidateId);
                    return false;
                }

                // Update properties
                existingCandidate.CandidateName = candidate.CandidateName;
                existingCandidate.CandidateLastName = candidate.CandidateLastName;
                existingCandidate.CvFilePath = candidate.CvFilePath;
                existingCandidate.RawTextCv = candidate.RawTextCv;
                existingCandidate.NeutralizedText = candidate.NeutralizedText;

                await _db.SaveChangesAsync();
                _logger.LogInformation("Candidate with ID {Id} updated.", candidate.CandidateId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating candidate with ID {Id}", candidate.CandidateId);
                return false;
            }
        }

        public async Task<bool> UpdateCandidateNeutralizedTxt(string neutralizedTxt, int candidateId)
        {
            try
            {
                var existingCandidate = await _db.Candidates.FindAsync(candidateId);
                if (existingCandidate == null)
                {
                    _logger.LogWarning("Candidate with ID {Id} not found.", candidateId);
                    return false;
                }

                // Update neutralized text propertie
                existingCandidate.NeutralizedText = neutralizedTxt;
                existingCandidate.isCvNeutralized = true;

                await _db.SaveChangesAsync();
                _logger.LogInformation("Candidate with ID {Id} updated.", candidateId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating candidate with ID {Id}", candidateId);
                return false;
            }
        }

        public async Task<bool> UpdateCandidateRawTxtCv(string rawTxtCv, int candidateId)
        {
            try
            {
                var existingCandidate = await _db.Candidates.FindAsync(candidateId);
                if (existingCandidate == null)
                {
                    _logger.LogWarning("Candidate with ID {Id} not found.", candidateId);
                    return false;
                }

                // Update neutralized text propertie
                existingCandidate.RawTextCv = rawTxtCv;

                await _db.SaveChangesAsync();
                _logger.LogInformation("Candidate with ID {Id} updated.", candidateId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating candidate with ID {Id}", candidateId);
                return false;
            }
        }
    }
}
