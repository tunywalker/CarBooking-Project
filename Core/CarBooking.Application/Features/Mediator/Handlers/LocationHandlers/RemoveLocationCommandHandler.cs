﻿using CarBooking.Application.Features.Mediator.Commands.LocationCommands;
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
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveLocationCommand>
    {
        public IRepository<Location> _repository { get; set; }
        public RemoveTagCloudCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
       
        public async  Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
