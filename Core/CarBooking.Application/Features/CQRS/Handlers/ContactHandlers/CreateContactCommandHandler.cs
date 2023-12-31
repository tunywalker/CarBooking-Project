using CarBooking.Application.Features.CQRS.Commands.CategoryCommands;
using CarBooking.Application.Features.CQRS.Commands.ContactCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {

        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsnyc(new Contact
            {
                Email=command.Email,
                Message=command.Message,
                Name=command.Name,
                SendDate = command.SendDate,
                Subject=command.Subject
                
                

            });
        }
    }
}
