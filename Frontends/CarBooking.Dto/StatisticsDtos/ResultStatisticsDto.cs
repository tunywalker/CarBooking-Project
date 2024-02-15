using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
		public int authorCount { get; set; }
		public int blogCount { get; set; }
		public int brandCount { get; set; }
		public decimal avgPriceForDaily { get; set; }
		public decimal avgPriceForWeekly { get; set; }
		public decimal avgPriceForMonthly { get; set; }

		public int carCountByTransmissionIsAuto { get; set; }

		public string brandNameByMaximumCar { get; set; }
        public int carCountByFuelElectric { get; set; }

        public int carCountByBeloveThan10000Km { get; set; }

        public int carCountByGasolineOrDiesel { get; set; }


    }
}
