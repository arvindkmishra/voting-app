using VotingApp.Infrastructure.Models;

namespace VotingApp.Infrastructure.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> Get(int? candidateId);

        Task<Candidate> Add(string name);

        Task<bool> Vote(int candidateId, int voterId);
    }
}
