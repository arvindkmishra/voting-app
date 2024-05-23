using Microsoft.EntityFrameworkCore;
using VotingApp.Infrastructure.Interfaces;
using VotingApp.Infrastructure.Models;

namespace VotingApp.Infrastructure.Repositories
{
    public class VoterRepository(VotingContext context) : IVoterRepository
    {
        private readonly VotingContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Voter>> Get(int? voterId)
        {
            return voterId.HasValue ?
                        _context.Voters.Where(voter => voter.Id == voterId).AsEnumerable() :
                        await _context.Voters.ToListAsync();
        }

        public async Task<Voter> Add(string fullName)
        {
            var voter = new Voter { Name = fullName, HasVoted = false };
            _context.Voters.Add(voter);
            await _context.SaveChangesAsync();
            return voter;
        }

        public async Task<bool> Vote(int candidateId, int voterId)
        {
            var candidate = await _context.Candidates.FindAsync(candidateId);
            var voter = await _context.Voters.FindAsync(voterId);

            if (candidate == null || voter == null || voter.HasVoted)
                return false;

            candidate.Votes++;
            voter.HasVoted = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
