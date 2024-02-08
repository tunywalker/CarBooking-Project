using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        double GetAvgRentPriceForDaily();
        double GetAvgRentPriceForWeekly();
        double GetAvgRentPriceForMonthly();
        int GetCarCountByTransmissionIsAuto();
        string BrandNameByMaxCar();
        string BlogTitleByByMaximumBlogComment();
        int GetCarCountByBeloveThan1000Km();
        int GetCarCountByGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceMax();
        string GetCarBrandAndModelByRentPriceMin();




    }
}
