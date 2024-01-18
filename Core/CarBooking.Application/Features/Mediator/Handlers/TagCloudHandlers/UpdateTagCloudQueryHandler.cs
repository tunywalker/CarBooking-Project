using CarBooking.Application.Features.Mediator.Commands.FeatureCommands;
using CarBooking.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudQueryHandler:IRequestHandler<UpdateTagCloudCommand>
    {
        public IRepository<TagCloud> _repository { get; set; }
        public UpdateTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
      
        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudID);
            value.BlogID = request.TagCloudID;
            value.Title = request.Title;
            
            await _repository.UpdateAsnyc(value);
        }
    }
}
