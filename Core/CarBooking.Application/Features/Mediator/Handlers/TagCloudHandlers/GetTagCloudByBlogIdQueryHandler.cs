using CarBooking.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBooking.Application.Features.Mediator.Results.TagCloudResults;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagClougByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
	{

		private readonly ITagCloudRepository _tagCloudRepository;

		public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
		{
			_tagCloudRepository = tagCloudRepository;
		}

		public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagClougByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var values=  _tagCloudRepository.GetTagCloudsByBlogID(request.BlogId).Select
				(x => new GetTagCloudByBlogIdQueryResult
				{
					BlogID = x.BlogID,
					Title = x.Title,
					TagCloudID = x.TagCloudID
				}).ToList();

			return values;



		}
	}
}
