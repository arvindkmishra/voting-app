using MediatR;
using VotingApp.Infrastructure.Interfaces;

namespace VotingApp.Core.Commands
{
    public class AddVoteCommand : IRequest<bool>
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }

        internal class Handler(IVoterRepository repository) : IRequestHandler<AddVoteCommand, bool>
        {
            private readonly IVoterRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            public async Task<bool> Handle(AddVoteCommand request, CancellationToken cancellationToken)
            {
                var response = await _repository.Vote(request.CandidateId, request.VoterId);

                return response;
            }
        }
    }
}
