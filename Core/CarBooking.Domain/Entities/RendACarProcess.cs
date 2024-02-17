﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
	public class RentACarProcess
	{
		public int RentACarProcessID { get; set; }
		public int CarId { get; set; }
		public Car Car { get; set; }
		public int PickUpLocation { get; set; }
		public int DropOffLocation { get; set; }

		[Column(TypeName ="Date")]
		public DateTime PickUpDate { get; set; }
		[Column(TypeName = "Date")]
		public DateTime DropOffDate { get; set; }
		[DataType(DataType.Time)]
		public TimeSpan PickUpTime { get; set; }
		[DataType(DataType.Time)]
		public TimeSpan DropOffTime { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
        public string PickUpDecription { get; set; }
		public string DropOffDecription { get; set; }
        public decimal TotalPrice { get; set; }



    }
}
