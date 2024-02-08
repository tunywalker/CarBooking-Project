using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using CarBooking.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBooking.Application.Features.Mediator.Results.StatisticsResults;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarCountQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

     

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            int carCount =  _repository.GetCarCount();
           return new GetCarCountQueryResult 
           {
               CarCount = carCount,
           };
        }
    }
}
