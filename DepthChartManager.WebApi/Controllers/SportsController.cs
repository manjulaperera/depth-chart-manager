using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Messaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepthChartManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSport([FromBody] CreateSportDto createSportDto)
        {
            var result = await _mediator.Send(new AddSportCommand(createSportDto));
            return result ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
