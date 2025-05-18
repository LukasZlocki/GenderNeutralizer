namespace GenderNeutralizer.App.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string? CandidateName { get; set; }
        public string? CandidateLastName { get; set; }
        public string? CvFilePath { get; set; }
        public string? RawTextCv { get; set; }
        public string? NeutralizedText { get; set; }
    }
}
