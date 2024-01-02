﻿using CarBooking.Application.Features.Mediator.Results.FooterAdressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Queries.FooterAdressQueries
{
    public class GetFooterAdressQuery:IRequest<List<GetFooterAdressQueryResult>>
    {
    }
}
