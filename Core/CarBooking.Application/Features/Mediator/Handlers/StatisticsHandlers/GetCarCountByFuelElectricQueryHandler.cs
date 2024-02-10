using CarBooking.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBooking.Application.Features.Mediator.Results.StatisticsResults;
using CarBooking.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    internal class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelElectricQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            int value = _repository.GetCarCountByFuelElectric();
            return new GetCarCountByFuelElectricQueryResult
            {
                CarCountByFuelElectricQueryResult = value,
            };
        }





    }
}