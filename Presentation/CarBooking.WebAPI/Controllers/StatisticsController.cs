using CarBooking.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebAPI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]

        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }
        [HttpGet("BrandNameByMaxCar")]

        public async Task<IActionResult> BrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }

    }
}
