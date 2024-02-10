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
    public class GetCarCountByBeloveThan1000KmQueryHandler : IRequestHandler<GetCarCountByBeloveThan1000KmQuery, GetCarCountByBeloveThan1000KmQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByBeloveThan1000KmQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByBeloveThan1000KmQueryResult> Handle(GetCarCountByBeloveThan1000KmQuery request, CancellationToken cancellationToken)
        {
            int value = _repository.GetCarCountByBeloveThan1000Km();
            return new GetCarCountByBeloveThan1000KmQueryResult
            {
                CarCountByBeloveThan1000Km = value,
            };
        }





    }
}

