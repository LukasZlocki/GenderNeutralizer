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

    }
}
