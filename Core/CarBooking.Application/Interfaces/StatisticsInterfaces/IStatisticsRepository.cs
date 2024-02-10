using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        int GetCarCountByTransmissionIsAuto();
        string GetBrandNameByMaxCar();
        string GetBlogTitleByMaximumBlogComment();
        int GetCarCountByBeloveThan1000Km();
        int GetCarCountByGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceMax();
        string GetCarBrandAndModelByRentPriceMin();




    }
}
