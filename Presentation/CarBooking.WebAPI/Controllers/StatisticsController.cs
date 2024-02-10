﻿using CarBooking.Application.Features.Mediator.Queries.StatisticsQueries;
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
      
        [HttpGet("GetLocationCount")]

        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }
        [HttpGet("GetAuthorCount")]

        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogCount")]

        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBrandCount")]

        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }
        //
        [HttpGet("GetAvgRentPriceForDaily")]

        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(values);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]

        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);
        }
        [HttpGet("GetAvgRentPriceForMonthly")]

        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(values);
        }
        [HttpGet("GetCarCountByTransmissionIsAuto")]

        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(values);
        }
        [HttpGet("GetBrandNameByMaxCar")]

        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogTitleByByMaximumBlogComment")]

        public async Task<IActionResult> GetBlogTitleByByMaximumBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]

        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceMax")]

        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceMaxQuery());
            return Ok(values);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceMin")]

        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceMinQuery());
            return Ok(values);
        }
    }
}
