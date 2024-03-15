﻿using CarBooking.Application.ViewModels;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingsWithCars();
        List<CarPricing> GetTimePricingWithTimePeriod();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();

	}
}
