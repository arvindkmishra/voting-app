using VotingApp.Domain.Entities;

namespace VotingApp.Domain.Interfaces
{
    public interface IVoterService
    {
        Task<IEnumerable<Voter>> GetVoters();
        Task<Voter> AddVoter(string name);
    }
}
