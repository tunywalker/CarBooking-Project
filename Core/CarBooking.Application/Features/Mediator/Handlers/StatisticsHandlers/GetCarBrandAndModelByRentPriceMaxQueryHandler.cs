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
    public class GetCarBrandAndModelByRentPriceMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMaxQuery, GetCarBrandAndModelByRentPriceMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarBrandAndModelByRentPriceMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceMax();
            return new GetCarBrandAndModelByRentPriceMaxQueryResult
            {
                CarBrandAndModelByRentPriceMax = value,
            };
        }





    }
}
