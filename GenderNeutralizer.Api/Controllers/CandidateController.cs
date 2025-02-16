using GenderNeutralizer.Api.Models;
using GenderNeutralizer.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenderNeutralizer.Api.Controllers
{
    public class CandidateController : Controller
    {
        private readonly CandidateService _dbCandidate;

        public CandidateController(CandidateService dbCandidate)
        {
            _dbCandidate = dbCandidate;
        }

        // GET
        [HttpGet("api/candidate")]
        public IActionResult GetAllCandidates()
        {
            var candidates = _dbCandidate.GetAllCandidates();
            return Ok(candidates);
        }

        // GET
        [HttpGet("api/candidate/{id}")]
        public IActionResult GetCandidate(Guid id)
        {
            var candidate = _dbCandidate.GetCandidateById(id);
            return Ok(candidate);
        }

        // CREATE
        [HttpPost("api/candidateCreate")]
        public IActionResult CreateCandidate([FromBody] Candidate candidate)
        {
            try
            {
                var result = _dbCandidate.AddCandidate(candidate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
