using Microsoft.EntityFrameworkCore;
using VotingApp.Infrastructure.Models;

namespace VotingApp.Infrastructure
{
    public class VotingContext : DbContext
    {
        public VotingContext(DbContextOptions<VotingContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
    }
}
