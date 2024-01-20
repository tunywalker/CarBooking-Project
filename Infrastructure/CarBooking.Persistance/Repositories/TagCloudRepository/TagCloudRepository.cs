using CarBooking.Application.Interfaces.TagCloudInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistance.Repositories.TagCloudRepository
{
	public class TagCloudRepository : ITagCloudRepository
	{
		private readonly CarBookContext _context;

		public TagCloudRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<TagCloud> GetTagCloudsByBlogID(int blogID)
		{
			var values=_context.TagClouds.Where(x=> x.BlogID== blogID).ToList();
			return values;
		}
	}
}
