using CarBooking.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBooking.Application.Features.Mediator.Results.TestimonialResults;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery,GetTestimonialByIdQueryResult>
    {
        public IRepository<Testimonial> _repository { get; set; }
        public GetServiceByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        async Task<GetTestimonialByIdQueryResult> IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>.Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                Name=value.Name,
                Comment=value.Comment,
                ImageUrl=value.ImageUrl,
                Title=value.Title
                

            };
        }
    }
}
