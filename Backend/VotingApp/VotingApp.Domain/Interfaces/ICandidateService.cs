using VotingApp.Domain.Entities;

namespace VotingApp.Domain.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetCandidates();
        Task<Candidate> AddCandidate(string name);
        Task<bool> Vote(int candidateId, int voterId);
    }
}
