using CarBooking.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeautureByIdQuery:IRequest<GetFeatureByIdQueryResult>
    {
        public int Id { get; set; }
        public GetFeautureByIdQuery(int id)
        {
            Id = id;
        }

       

    }
}
