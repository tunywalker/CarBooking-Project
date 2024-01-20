﻿using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Interfaces.TagCloudInterfaces
{
	public interface ITagCloudRepository
	{
		List<TagCloud> GetTagCloudsByBlogID(int blogID);
	}
}
