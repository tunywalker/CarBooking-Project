﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.AuthorDtos
{
	public class ResultAuthorDto
	{
		public int authorId { get; set; }
		public string name { get; set; }
		public string imageUrl { get; set; }
		public string description { get; set; }
	}
}
