using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.CarPricingDtos
{
	public class ResultCarPricingListWithModelDto
	{
		public string model { get; set; }
		public string brandName { get; set; }
		public string coverImageUrl { get; set; }
		public decimal dailyAmount { get; set; }
		public decimal weeklyAmount { get; set; }
		public decimal monthlyAmount { get; set; }


	}
}
