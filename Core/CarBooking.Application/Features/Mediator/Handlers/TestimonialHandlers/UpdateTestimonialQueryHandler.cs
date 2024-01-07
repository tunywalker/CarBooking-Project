using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
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
    public class UpdateLocationQueryHandler:IRequestHandler<UpdateTestimonialCommand>
    {
        public IRepository<Testimonial> _repository { get; set; }
        public UpdateLocationQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
      
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            value.ImageUrl = request.ImageUrl;
            value.Comment = request.Comment;
            value.Title = request.Title;
            value.Name= request.Name;
            await _repository.UpdateAsnyc(value);
        }
    }
}
