using CarBooking.Application.Features.Mediator.Commands.ServiceCommands;
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
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        public IRepository<Service> _repository { get; set; }
        public CreateSocialMediaCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var value=new Service()
            {
                Description=request.Description,
                IconUrl=request.IconUrl,    
                Title=request.Title,
                    
            };
            await _repository.CreateAsnyc(value);
        }
    }
}
