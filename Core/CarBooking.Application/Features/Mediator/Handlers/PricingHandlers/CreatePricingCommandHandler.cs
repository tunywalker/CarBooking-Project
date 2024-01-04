using CarBooking.Application.Features.Mediator.Commands.PricingCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler:IRequestHandler<CreatePricingCommand>
    {
        IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsnyc(new Pricing()
            {
                Name = request.Name,
            });
        }
    }
}
