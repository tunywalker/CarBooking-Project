using CarBooking.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIdQuery:IRequest<GetBlogByAuthorIdQueryResult>
    {
        public int AuthorId { get; set; }

        public GetBlogByAuthorIdQuery(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
