using MediatR;
using VotingApp.Core.DTOs;
using VotingApp.Infrastructure.Interfaces;

namespace VotingApp.Core.Commands
{
    public class AddVoterCommand : IRequest<VoterDto>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        internal class Handler(IVoterRepository repository) : IRequestHandler<AddVoterCommand, VoterDto>
        {
            private readonly IVoterRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            public async Task<VoterDto?> Handle(AddVoterCommand request, CancellationToken cancellationToken)
            {
                var response = await _repository.Add($"{request.FirstName} {request.LastName}");

                if (response.Id > 0)
                {
                    //we can use auto mapper to map properties
                    return new VoterDto()
                    {
                        Id = response.Id,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                    };
                }
                else
                    return default;
            }
        }
    }
}
