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
    public class GetBlogQueryHandler:IRequestHandler<GetBlogQuery,List<GetBlogQueryResult>>
    {
        public IRepository<Blog> _repository { get; set; }
        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult()
            {
               AuthorId = x.AuthorId,
               CategoryId = x.CategoryId,
               BlogID = x.BlogID,
               CoverImageUrl = x.CoverImageUrl,
               Title = x.Title,
               CreatedDate = x.CreatedDate
                
            }).ToList();


        }
    }
}
