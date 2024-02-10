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
    public  class GetCarBrandAndModelByRentPriceMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMinQuery, GetCarBrandAndModelByRentPriceMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarBrandAndModelByRentPriceMinQueryResult> Handle(GetCarBrandAndModelByRentPriceMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceMin();
            return new GetCarBrandAndModelByRentPriceMinQueryResult
            {
                CarBrandAndModelByRentPriceMin = value,
            };
        }





    }
}