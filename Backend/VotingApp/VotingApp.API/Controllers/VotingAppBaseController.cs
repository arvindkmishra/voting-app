using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VotingApp.API.Controllers
{
    public class VotingAppBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public VotingAppBaseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
