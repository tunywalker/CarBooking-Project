using CarBooking.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        public IRepository<Testimonial> _repository { get; set; }
        public CreateServiceCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value=new Testimonial()
            {
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
               Title = request.Title,
            };
            await _repository.CreateAsnyc(value);
        }
    }
}
