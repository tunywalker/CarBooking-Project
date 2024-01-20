using CarBooking.Application.Features.Mediator.Queries.BlogQueries;
using CarBooking.Application.Features.Mediator.Results.BlogResults;
using CarBooking.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, GetBlogByAuthorIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByAuthorIdQueryResult> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetBlogByAuthorId(request.AuthorId);
            return new GetBlogByAuthorIdQueryResult()
            {
               
                BlogID = value.BlogID,
                AuthorId = value.AuthorId,
                AuthorName = value.Author.Name,
                AuthorDescription =value.Author.Description,
                AuthorImageUrl=value.Author.ImageUrl,
                

            };
        }
    }
}
