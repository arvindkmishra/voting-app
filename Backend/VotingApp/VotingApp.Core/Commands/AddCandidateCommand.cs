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
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        TotalVotes = 0
                    };
                }
                else
                    return default;
            }
        }
    }
}
