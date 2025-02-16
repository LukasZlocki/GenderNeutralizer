using GenderNeutralizer.Api.DTOs;
using GenderNeutralizer.Api.ModelDtos;
using GenderNeutralizer.Api.Models;
using GenderNeutralizer.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenderNeutralizer.Api.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET
        [HttpGet("api/candidate")]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        // GET
        [HttpGet("api/candidate/{id}")]
        public async Task<IActionResult> GetCandidate(Guid id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            return Ok(candidate);
        }

        // CREATE
        [HttpPost("api/candidateCreate")]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateReadDto candidateReadDto)
        {
            var candidate = SerializeCandidateReadDTO.SerializeReadDtoToCandidateObject(candidateReadDto);
           
            try
            {
                var result = _candidateService.AddCandidate(candidate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
