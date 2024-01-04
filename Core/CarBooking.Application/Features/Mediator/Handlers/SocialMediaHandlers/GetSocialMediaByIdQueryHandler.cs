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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        public IRepository<SocialMedia> _repository { get; set; }
        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        async Task<GetSocialMediaByIdQueryResult> IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>.Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                Url = value.Url,
                Icon = value.Icon,
                Name = value.Name,
                SocialMediaId = value.SocialMediaId
            };
        }
    }
}
