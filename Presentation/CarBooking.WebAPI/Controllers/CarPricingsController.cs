﻿using CarBooking.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }
		[HttpGet("withTimePeriodList")]
		public async Task<IActionResult> GetCarPricingWithTimePeriodList()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}
	}
}
