namespace GenderNeutralizer.Api.ModelDtos
{
    public class CandidateReadDto
    {
        public string CandidateName { get; set; }
        public string CandidateLastName { get; set; }
        public string TextCv { get; set; }
        public string TextCvNeutralized { get; set; }
    }
}
