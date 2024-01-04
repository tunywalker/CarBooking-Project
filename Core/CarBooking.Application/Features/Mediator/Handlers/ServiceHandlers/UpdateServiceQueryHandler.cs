using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
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
    public class UpdateSocialMediaQueryHandler:IRequestHandler<UpdateServiceCommand>
    {
        public IRepository<Service> _repository { get; set; }
        public UpdateSocialMediaQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
      
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            value.Description = request.Description;
            value.Title = request.Title;
            value.IconUrl = request.IconUrl;
            
            await _repository.UpdateAsnyc(value);
        }
    }
}
