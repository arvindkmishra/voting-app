using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Commands;
using VotingApp.Core.DTOs;
using VotingApp.Core.Queries;

namespace VotingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController(IMediator mediator) : VotingAppBaseController(mediator)
    {
        [HttpGet]
        public async Task<IEnumerable<CandidateDto>> Get([FromQuery]GetCandidatesQuery getCandidateQuery)
        {
            return await _mediator.Send(getCandidateQuery);
        }

        [HttpPost]
        public async Task<ActionResult<CandidateDto>> Post(AddCandidateCommand candidate)
        {
            var result = await _mediator.Send(candidate);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
