using CarBooking.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBooking.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        public IRepository<SocialMedia> _repository { get; set; }
        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value=new SocialMedia()
            {
               Icon=request.Icon
               , Name=request.Name,
               Url=request.Url
                    
            };
            await _repository.CreateAsnyc(value);
        }
    }
}
