using CarBooking.Application.Features.Mediator.Commands.LocationCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        public IRepository<Location> _repository { get; set; }
        public CreateServiceCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var value=new Location()
            {
                Name = request.Name
            };
            await _repository.CreateAsnyc(value);
        }
    }
}
