using Microsoft.EntityFrameworkCore;
using VotingApp.Infrastructure.Interfaces;
using VotingApp.Infrastructure.Models;

namespace VotingApp.Infrastructure.Repositories
{
    public class CandidateRepository(VotingContext context) : ICandidateRepository
    {
        private readonly VotingContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Candidate>> Get(int? candidateId)
        {
            return candidateId.HasValue ?
                       _context.Candidates.Where(candidate => candidate.Id == candidateId).AsEnumerable() :
                       await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate> Add(string name)
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
