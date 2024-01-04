using CarBooking.Application.Features.Mediator.Queries.PricingQueries;
using CarBooking.Application.Features.Mediator.Results.PricingResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        IRepository<Pricing> _repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        async Task<List<GetPricingQueryResult>> IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>.Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult()
            {
                PricingId = x.PricingId,
                Name = x.Name,

            }).ToList();
        }
    }
}
