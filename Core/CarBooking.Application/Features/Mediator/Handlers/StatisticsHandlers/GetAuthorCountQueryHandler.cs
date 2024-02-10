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
    internal class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAuthorCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            int value = _repository.GetAuthorCount();
            return new GetAuthorCountQueryResult
            {
                AuthorCount = value,
            };
        }





    }
}