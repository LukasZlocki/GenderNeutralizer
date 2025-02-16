namespace GenderNeutralizer.Api.Models
{
    public class Candidate
    {
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateLastName{ get; set; }
        public string TextCv { get; set; }
        public string TextCvNeutralized { get; set; }
    }
}
