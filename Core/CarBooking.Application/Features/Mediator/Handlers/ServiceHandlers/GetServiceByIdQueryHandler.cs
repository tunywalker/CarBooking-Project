using CarBooking.Application.Features.Mediator.Queries.ServiceQueries;
using CarBooking.Application.Features.Mediator.Results.ServiceResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public IRepository<Service> _repository { get; set; }
        public GetSocialMediaByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        async Task<GetServiceByIdQueryResult> IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>.Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,
                ServiceId = value.ServiceId,
            };
        }
    }
}
