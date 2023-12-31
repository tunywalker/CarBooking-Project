using CarBooking.Application.Features.CQRS.Results.CategoryResults;
using CarBooking.Application.Features.CQRS.Results.ContactResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Email = x.Email,
                Subject = x.Subject,
                SendDate = x.SendDate,
                Name = x.Name,
                Message = x.Message
            }).ToList();
        }
    }
}
