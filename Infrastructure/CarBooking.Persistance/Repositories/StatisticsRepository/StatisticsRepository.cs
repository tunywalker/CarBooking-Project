using CarBooking.Application.Interfaces.StatisticsInterfaces;
using CarBooking.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistance.Repositories.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByByMaximumBlogComment()
        {
            throw new NotImplementedException();
        }

        public string GetBrandNameByMaxCar()
        {
            var value = _context.Cars.GroupBy(car => car.BrandId)
            .Select(group => new
            {
                BrandID = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(x => x.Count)
            .FirstOrDefault();
            var brand = _context.Brands.Where(x => x.BrandId.Equals(value.BrandID)).FirstOrDefault().Name;
            return brand;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(g => g.PricingId == id).Average(x => x.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(g => g.PricingId == id).Average(x => x.Amount);
            return value;
        }
        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(g => g.PricingId == id).Average(x => x.Amount);
            return value;
        }



        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceMin()
        {
            //var value = _context.CarPricings.Where(x => x.PricingId == _context.Pricings.Where(x => x.Name.Equals("Günlük")).S.ToList();
            throw new NotImplementedException();

        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByBeloveThan1000Km()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
