namespace VotingApp.Core.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalVotes { get; set; }
    }
}
