using CarBooking.Application.Features.CQRS.Commands.AboutCommands;
using CarBooking.Application.Features.CQRS.Commands.BrandCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateBrandCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var value=await _repository.GetByIdAsync(command.BrandId);
            value.Name = command.Name;
            await _repository.UpdateAsnyc(value);

        }


    }
}
