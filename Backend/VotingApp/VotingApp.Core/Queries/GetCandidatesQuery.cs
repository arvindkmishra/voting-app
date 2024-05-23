using MediatR;
using VotingApp.Core.DTOs;
using VotingApp.Infrastructure.Interfaces;

namespace VotingApp.Core.Queries
{
    public class GetCandidatesQuery : IRequest<IEnumerable<CandidateDto>>
    {
        public int? Id { get; set; }

        public class Handler(ICandidateRepository repository) : IRequestHandler<GetCandidatesQuery, IEnumerable<CandidateDto>>
        {
            private readonly ICandidateRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            public async Task<IEnumerable<CandidateDto>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
            {
                string[] names = default;
                var voters = await _repository.Get(request.Id);

                return voters.Select(voter =>
                {
                    names = voter.Name.Split(' ');
                    return new CandidateDto
                    {
                        Id = voter.Id,
                        FirstName = names[0] ?? string.Empty,
                        LastName = names[1] ?? string.Empty
                    };
                });
            }
        }
    }
}
