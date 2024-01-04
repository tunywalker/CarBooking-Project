using CarBooking.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBooking.Application.Features.Mediator.Results.SocialMediaResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler:IRequestHandler<GetSocialMediaQuery,List<GetSocialMediaQueryResult>>
    {
        public IRepository<SocialMedia> _repository { get; set; }
        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult()
            {
               Icon = x.Icon,
               Name = x.Name,
               SocialMediaId    = x.SocialMediaId,
               Url = x.Url,
            }).ToList();


        }
    }
}
