﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
	public class RentACar
	{
        public int RentACarId { get; set; }
		public int LocationId { get; set; }	

        public int CarId { get; set; }
		public Car Car { get; set; }
        public bool Avaible { get; set; }

	}
}
