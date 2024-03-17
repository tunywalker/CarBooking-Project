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



		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{

			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = @"
    SELECT * 
    FROM (
        SELECT 
			B.Name,
            C.Model,
			C.CoverImageUrl,
            CP.PricingId,
            CP.Amount
        FROM CarPricings CP
        INNER JOIN Cars C ON CP.CarID = C.CarID
        INNER JOIN Brands B ON C.BrandId = B.BrandId
    ) AS SourceTable
    PIVOT (
        SUM(Amount) 
        FOR PricingId IN ([1], [2], [3])
    ) AS PivotTable;"; command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{

					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Model = reader["Model"].ToString(),
							BrandName = reader["Name"].ToString(),
							CoverImageUrl= reader["CoverImageUrl"].ToString(),
							Amounts= new List<decimal>()
							{
								Convert.ToDecimal(reader["1"]),
								Convert.ToDecimal(reader["2"]),
								Convert.ToDecimal(reader["3"]),
							}



						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}


	}

}
