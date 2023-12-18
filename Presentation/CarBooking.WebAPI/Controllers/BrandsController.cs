using CarBooking.Application.Features.CQRS.Commands.BrandCommands;
using CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBooking.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHander;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHander;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(GetBrandQueryHandler getBrandQueryHander, GetBrandByIdQueryHandler getBrandByIdQueryHander, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _getBrandQueryHander = getBrandQueryHander;
            _getBrandByIdQueryHander = getBrandByIdQueryHander;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHander.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrad(int id)
        {
            var value = await _getBrandByIdQueryHander.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Bilgi eklendi.");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Bilgi silindi.");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Bilgi güncellendi.");

        }
    }
}
