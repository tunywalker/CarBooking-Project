using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBooking.Application.Features.Mediator.Results.CarPricingResults;
using CarBooking.Application.Features.Mediator.Results.LocationResults;
using CarBooking.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        public ICarPricingRepository _repository { get; set; }
        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        { 
            var values =  _repository.GetCarPricingsWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult()
            {
              Amount = x.Amount,
              Brand=x.Car.Brand.Name,
              CarPricingId=x.CarPricingId,
              CoverImageUrl=x.Car.CoverImageUrl,
              Model=x.Car.Model,
              CarId=x.Car.CarId,
              

            }).ToList();

        }
    }
}
