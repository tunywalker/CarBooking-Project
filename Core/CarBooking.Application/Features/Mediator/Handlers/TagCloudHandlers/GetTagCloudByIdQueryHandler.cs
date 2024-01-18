using CarBooking.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBooking.Application.Features.Mediator.Results.TagCloudResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery,GetTagCloudByIdQueryResult>
    {
        public IRepository<TagCloud> _repository { get; set; }
        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        async Task<GetTagCloudByIdQueryResult> IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>.Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                BlogID = value.BlogID,
                Title = value.Title,
                TagCloudID=value.TagCloudID  
                
            };
        }
    }
}
