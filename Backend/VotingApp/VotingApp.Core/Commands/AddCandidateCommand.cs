using MediatR;
using VotingApp.Core.DTOs;
using VotingApp.Infrastructure.Interfaces;

namespace VotingApp.Core.Commands
{
    public class AddCandidateCommand : IRequest<CandidateDto>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        internal class Handler(ICandidateRepository repository) : IRequestHandler<AddCandidateCommand, CandidateDto>
        {
            private readonly ICandidateRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            public async Task<CandidateDto?> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
            {
                var response = await _repository.Add($"{request.FirstName} {request.LastName}");

                if (response.Id > 0)
                {
                    //we can use auto mapper to map properties
                    return new CandidateDto()
                    {
                        Id = response.Id,
                        FullName = $"{request.FirstName} {request.LastName}",
                        TotalVotes = response.Votes
                    };
                }
                else
                    return default;
            }
        }
    }
}
