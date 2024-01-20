using CarBooking.Application.Features.Mediator.Queries.BlogQueries;
using CarBooking.Application.Features.Mediator.Results.BlogResults;
using CarBooking.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorsQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
       
   

        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

    public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
    {
            var values =  _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult()
            {
                AuthorId = x.AuthorId,
                BlogID = x.BlogID,
                CategoryId = x.CategoryId,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                AuthorName = x.Author.Name,
                CategoryName=x.Category.Name,
                Description=x.Description,
                AuthorDescription=x.Author.Description,
                AuthorImageUrl=x.Author.ImageUrl,
               
                





            }).ToList();
        }
    }
}
