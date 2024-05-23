using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Commands;
using VotingApp.Core.DTOs;
using VotingApp.Core.Queries;

namespace VotingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotersController(IMediator mediator) : VotingAppBaseController(mediator)
    {
        [HttpGet]
        public async Task<IEnumerable<VoterDto>> Get([FromQuery] GetVotersQuery getVoterQuery)
        {
            return await _mediator.Send(getVoterQuery);
        }

        [HttpPost]
        public async Task<ActionResult<VoterDto>> Post(AddVoterCommand voter)
        {
            var result = await _mediator.Send(voter);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
