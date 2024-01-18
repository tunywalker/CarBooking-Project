using CarBooking.Application.Features.Mediator.Queries.BlogQueries;
using CarBooking.Application.Features.Mediator.Results.BlogResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery,GetBlogByIdQueryResult>
    {
        public IRepository<Blog> _repository { get; set; }
        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        async Task<GetBlogByIdQueryResult> IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>.Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
               BlogID = value.BlogID,
               AuthorId = value.AuthorId,
               Description=value.Description,
               CategoryId = value.CategoryId,
               CoverImageUrl = value.CoverImageUrl,
               CreatedDate = value.CreatedDate,
               Title = value.Title

              
            };
        }
    }
}
