using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand:IRequest
    {
        public RemoveAuthorCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
