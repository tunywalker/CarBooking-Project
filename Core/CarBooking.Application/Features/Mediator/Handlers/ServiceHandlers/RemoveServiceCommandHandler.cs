using CarBooking.Application.Features.Mediator.Commands.ServiceCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        public IRepository<Service> _repository { get; set; }
        public RemoveSocialMediaCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
       
        public async  Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
