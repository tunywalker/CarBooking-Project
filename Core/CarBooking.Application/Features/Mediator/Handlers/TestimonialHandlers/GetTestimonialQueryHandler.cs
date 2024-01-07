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
    public class GetTestimonialQueryHandler:IRequestHandler<GetTestimonialQuery,List<GetTestimonialQueryResult>>
    {
        public IRepository<Testimonial> _repository { get; set; }
        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult()
            {
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name=x.Name,
                Title=x.Title,
                TestimonialId = x.TestimonialId
            }).ToList();


        }
    }
}
