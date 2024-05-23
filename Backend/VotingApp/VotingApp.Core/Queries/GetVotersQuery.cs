using MediatR;
using VotingApp.Core.DTOs;
using VotingApp.Infrastructure.Interfaces;

namespace VotingApp.Core.Queries
{
    public class GetVotersQuery : IRequest<IEnumerable<VoterDto>>
    {
        public int? Id { get; set; }

        public class Handler(IVoterRepository repository) : IRequestHandler<GetVotersQuery, IEnumerable<VoterDto>>
        {
            private readonly IVoterRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            public async Task<IEnumerable<VoterDto>> Handle(GetVotersQuery request, CancellationToken cancellationToken)
            {
                string[] names = default;
                var voters = await _repository.Get(request.Id);

                return voters.Select(voter =>
                {
                    names = voter.Name.Split(' ');
                    return new VoterDto
                    {
                        Id = voter.Id,
                        FirstName = names[0] ?? string.Empty,
                        LastName = names[1] ?? string.Empty,
                        HasVotes = voter.HasVoted
                    };
                });
            }
        }
    }
}
