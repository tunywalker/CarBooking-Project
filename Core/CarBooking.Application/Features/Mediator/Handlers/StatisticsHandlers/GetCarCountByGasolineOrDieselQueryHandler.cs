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
    public class GetCarCountByGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByGasolineOrDieselQuery, GetCarCountByGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByGasolineOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByGasolineOrDieselQueryResult> Handle(GetCarCountByGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            int value = _repository.GetCarCountByGasolineOrDiesel();
            return new GetCarCountByGasolineOrDieselQueryResult
            {
                CarCountByGasolineOrDiesel = value,
            };
        }





    }
}

