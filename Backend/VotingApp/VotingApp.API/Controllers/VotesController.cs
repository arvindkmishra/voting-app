using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Commands;

namespace VotingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotesController(IMediator mediator) : VotingAppBaseController(mediator)
    {

        [HttpPost]
        public async Task<IActionResult> Post(AddVoteCommand vote)
        {
            var success = await _mediator.Send(vote);
            if (!success)
            {
                return BadRequest("Invalid voter or voter has already voted.");
            }
            return NoContent();
        }
    }
}
