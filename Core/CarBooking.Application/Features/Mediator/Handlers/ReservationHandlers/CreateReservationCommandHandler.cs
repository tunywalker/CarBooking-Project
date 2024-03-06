using CarBooking.Application.Features.Mediator.Commands.ReservationCommands;
using CarBooking.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {


        public IRepository<Reservation> _repository { get; set; }
        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }



        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var value = new Reservation()
            {
                Age = request.Age,
                CarID = request.CarID,
                Decription = request.Description,
                DriverLicenseAge = request.DriverLicenseAge,
                DropOffLocationID = request.DropOffLocationID,
                PickUpLocationID = request.PickUpLocationID,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone,



            };
            await _repository.CreateAsnyc(value);
        }
    }
}
