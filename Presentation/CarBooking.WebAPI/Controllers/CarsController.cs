using CarBooking.Application.Features.CQRS.Commands.CarCommands;
using CarBooking.Application.Features.CQRS.Handlers.CarHandlers;
using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarQueryHandler _getCarQueryHander;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHander;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHander;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;


        public CarsController(GetCarQueryHandler getCarQueryHander, GetCarByIdQueryHandler getCarByIdQueryHander, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHander)
        {
            _getCarQueryHander = getCarQueryHander;
            _getCarByIdQueryHander = getCarByIdQueryHander;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHander = getCarWithBrandQueryHander;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHander.Handle();
            return Ok(values);
        }
        [HttpGet("GetCarWithBrand")]
        public  IActionResult GetCarWithBrand()
        {
            var values =  _getCarWithBrandQueryHander.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _getCarByIdQueryHander.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Bilgi eklendi.");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Bilgi silindi.");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Bilgi güncellendi.");

        }
    }
}
