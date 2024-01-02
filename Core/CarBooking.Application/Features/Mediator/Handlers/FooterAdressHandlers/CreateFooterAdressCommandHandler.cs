using CarBooking.Application.Features.Mediator.Commands.FooterAdressCommands;

using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.FooterAdresss.Mediator.Handlers.FooterAdressHandlers
{
    public class CreateFooterAdressCommandHandler : IRequestHandler<CreateFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public CreateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsnyc(new FooterAdress
            {
               Adress=request.Adress,
               Description=request.Description,
               Email=request.Email,
               Phone = request.Phone
            });
        }
    }
}
