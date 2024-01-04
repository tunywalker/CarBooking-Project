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
    public class GetSocialMediaQueryHandler:IRequestHandler<GetServiceQuery,List<GetServiceQueryResult>>
    {
        public IRepository<Service> _repository { get; set; }
        public GetSocialMediaQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult()
            {
               Description = x.Description,
               IconUrl = x.IconUrl,
               ServiceId  = x.ServiceId,
               Title= x.Title,
            }).ToList();


        }
    }
}
