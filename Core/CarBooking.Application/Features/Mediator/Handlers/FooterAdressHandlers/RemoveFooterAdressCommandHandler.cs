using CarBooking.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class RemoveFooterAdressCommandHandler : IRequestHandler<RemoveFooterAdressCommand>
    {
        IRepository<FooterAdress> _repository;

        public RemoveFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAdressCommand request, CancellationToken cancellationToken)
        {
           var value= await _repository.GetByIdAsync(request.Id);
           await _repository.RemoveAsync(value);

        }

    }
}
