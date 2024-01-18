﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.BlogDtos
{
	public class GetBlogByIdDto
	{
		public int BlogID { get; set; }
		public string Title { get; set; }
		public int AuthorId { get; set; }
		

		public string CoverImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CategoryId { get; set; }
		
		public string Description { get; set; }
	}
}
