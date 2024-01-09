using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
using CarBooking.Application.Features.Mediator.Commands.AuthorCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateServiceQueryHandler:IRequestHandler<UpdateAuthorCommand>
    {
        public IRepository<Author> _repository { get; set; }
        public UpdateServiceQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
      
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorId);
            value.Description = request.Description;
            value.Name = request.Name;
            
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsnyc(value);
        }
    }
}
