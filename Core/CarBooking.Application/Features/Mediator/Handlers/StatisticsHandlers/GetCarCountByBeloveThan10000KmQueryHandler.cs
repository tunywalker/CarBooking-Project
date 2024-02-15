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
    public class GetCarCountByBeloveThan10000KmQueryHandler : IRequestHandler<GetCarCountByBeloveThan10000KmQuery, GetCarCountByBeloveThan10000KmQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByBeloveThan10000KmQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByBeloveThan10000KmQueryResult> Handle(GetCarCountByBeloveThan10000KmQuery request, CancellationToken cancellationToken)
        {
            int value = _repository.GetCarCountByBeloveThan10000Km();
            return new GetCarCountByBeloveThan10000KmQueryResult
            {
                CarCountByBeloveThan10000Km = value,
            };
        }





    }
}

