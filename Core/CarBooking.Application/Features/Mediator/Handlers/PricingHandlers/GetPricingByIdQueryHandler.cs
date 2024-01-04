using CarBooking.Application.Features.CQRS.Results.AboutResults;
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
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

  
        async Task<GetPricingByIdQueryResult> IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>.Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult()
            {
                Name=value.Name,
                PricingId=value.PricingId
            };

        }
    }
}
