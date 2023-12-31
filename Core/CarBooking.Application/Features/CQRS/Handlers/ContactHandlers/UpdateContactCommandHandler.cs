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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactID);
            value.Name = command.Name;
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Email = command.Email;
            value.Message = command.Message;
            await _repository.UpdateAsnyc(value);
        }
    }
}
