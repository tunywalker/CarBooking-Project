using CarBooking.Application.Features.CQRS.Queries.CarQueries;
using CarBooking.Application.Features.CQRS.Results.CarResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandId = value.BrandId,
                BigImageUrl = value.BigImageUrl,
                CarId = value.CarId,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                Seat = value.Seat,
                Transmission = value.Transmission,
                Model = value.Model
            };
        }
    }
}
