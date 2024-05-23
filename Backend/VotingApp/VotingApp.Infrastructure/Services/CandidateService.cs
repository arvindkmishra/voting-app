using Microsoft.EntityFrameworkCore;
using VotingApp.Domain.Entities;
using VotingApp.Domain.Interfaces;

namespace VotingApp.Infrastructure.Services
{
    internal class CandidateService : ICandidateService
    {
        private readonly VotingContext _context;

        public CandidateService(VotingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate> AddCandidate(string name)
        {
            var candidate = new Candidate { Name = name, Votes = 0 };
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return candidate;
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
