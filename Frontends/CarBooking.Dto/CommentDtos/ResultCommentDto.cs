﻿using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.CommentDtos
{
	public class ResultCommentDto
	{
		public int CommentID { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }

		public string Description { get; set; }
		public int BlogID { get; set; }
		public Blog Blog { get; set; }
	}
}
