using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
using CarBooking.Application.Features.Mediator.Commands.BlogCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogQueryHandler:IRequestHandler<UpdateBlogCommand>
    {
        public IRepository<Blog> _repository { get; set; }
        public UpdateBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
      
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.AuthorId = request.AuthorId;
           value.CreatedDate = request.CreatedDate;
            value.CategoryId = request.CategoryId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.CreatedDate=request.CreatedDate;
            await _repository.UpdateAsnyc(value);
        }
    }
}
