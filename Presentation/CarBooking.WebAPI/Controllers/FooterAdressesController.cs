using CarBooking.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBooking.Application.Features.Mediator.Handlers.FooterAdressHandlers;
using CarBooking.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAdressesList()
        {
            var value =  await _mediator.Send(new GetFooterAdressQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adress başarıyla eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdress(int id)
        {
            var value = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("Footer adress başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adress başarıyla güncellendi.");
        }

    }
}
