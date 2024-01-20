﻿using CarBooking.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Queries.TagCloudQueries
{
	public class GetTagClougByBlogIdQuery:IRequest<List<GetTagCloudByBlogIdQueryResult>>
	{
        public int BlogId { get; set; }

		public GetTagClougByBlogIdQuery(int blogId)
		{
			BlogId = blogId;
		}
	}
}
