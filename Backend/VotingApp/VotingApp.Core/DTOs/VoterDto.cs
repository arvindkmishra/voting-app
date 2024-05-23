namespace VotingApp.Core.DTOs
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasVotes { get; set; }
    }
}
