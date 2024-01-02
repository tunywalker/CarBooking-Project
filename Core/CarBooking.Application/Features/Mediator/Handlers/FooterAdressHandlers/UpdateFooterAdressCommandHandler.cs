using CarBooking.Application.Features.CQRS.Commands.AboutCommands;
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
    public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
    {
        IRepository<FooterAdress> _repository;

        public UpdateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAdressId);
            value.Adress = request.Adress;
            value.Phone= request.Phone;
            value.Description = request.Description;
            value.Email = request.Email;
            await _repository.UpdateAsnyc(value);

           
        }
    }
}
