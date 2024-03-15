using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Application.Interfaces.CarPricingInterfaces;
using CarBooking.Application.ViewModels;
using CarBooking.Domain.Entities;
using CarBooking.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistance.Repositories.CarPricingRepository
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingsWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(z => z.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).ToList();
			return values;
		}

		public List<CarPricing> GetTimePricingWithTimePeriod()
		{

			throw new NotImplementedException();
			//var values = from x in _context.CarPricings
			//             group x by x.PricingId into g
			//             select new
			//             {
			//                 CarId = g.Key,
			//                 DailyPrice = g.Where(y => y.CarPricingId == 2).ToList().Sum(z => z.Amount),
			//                 WeeklyPrice = g.Where(y => y.CarPricingId == 2).ToList().Sum(z => z.Amount),
			//                 MonthlyPrice = g.Where(y => y.CarPricingId == 2).ToList().Sum(z => z.Amount)
			//             };
			//return values.ToList();
		}

		List<CarPricingViewModel> ICarPricingRepository.GetCarPricingWithTimePeriod()
		{

			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "select * from(Select (Brands.Name +' ' +Model) as Model,PricingId,AmountFrom CarPricingsInner Join CarsOn Cars.CarID=CarPricings.CarIdInner Join BrandsOn Brands.BrandId = Cars.BrandId)as SourceTablePivot (Sum(Amount) for PricingId In([1],[2],[3])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel();
						Enumerable.Range(1, 3).ToList().ForEach(x =>
						{
							{
								if (DBNull.Value.Equals(reader[x]))
								{
									carPricingViewModel.Amounts.Add(0);
								}
								else
								{
									carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
								}
							}
						});
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}
