namespace VotingApp.Core.DTOs
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool HasVotes { get; set; }
    }
}
