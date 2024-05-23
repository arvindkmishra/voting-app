using VotingApp.Infrastructure.Models;

namespace VotingApp.Infrastructure.Interfaces
{
    public interface IVoterRepository
    {
        Task<IEnumerable<Voter>> Get(int? voterId);

        Task<Voter> Add(string fullName);

        Task<bool> Vote(int candidateId, int voterId);
    }
}
