using GenderNeutralizer.Api.ModelDtos;
using GenderNeutralizer.Api.Models;

namespace GenderNeutralizer.Api.DTOs
{
    public static class SerializeCandidateReadDTO
    {
        public static Candidate SerializeReadDtoToCandidateObject(CandidateReadDto readDto)
        {
            return new Candidate
            {
                CandidateName = readDto.CandidateName,
                CandidateLastName = readDto.CandidateLastName,
                TextCv = readDto.TextCv,
                TextCvNeutralized = readDto.TextCvNeutralized
            };
        }

    }
}
