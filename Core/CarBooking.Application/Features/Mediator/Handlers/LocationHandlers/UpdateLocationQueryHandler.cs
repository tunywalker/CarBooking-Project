﻿using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
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
    public class UpdateLocationQueryHandler:IRequestHandler<UpdateLocationCommand>
    {
        public IRepository<Location> _repository { get; set; }
        public UpdateLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
      
        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationId);
            value.Name = request.Name;
            await _repository.UpdateAsnyc(value);
        }
    }
}
