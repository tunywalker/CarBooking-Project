using CarBooking.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBooking.Application.Features.Mediator.Results.FooterAdressResults;

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
    public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAdress> _repository;

        public GetFooterAdressByIdQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAdressByIdQueryResult
            {
                FooterAdressId = value.FooterAdressId,
                Adress=value.Adress,
                Description = value.Description,
                Phone = value.Phone,
                Email = value.Email
            };
        }
    }
}
