using CarBooking.Application.Features.CQRS.Commands.AboutCommands;
using CarBooking.Application.Features.CQRS.Commands.BannerCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            this._repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerId);
            values.VideoDescription = command.VideoDescription;
            values.Title = command.Title;
            values.Description = command.Description;
            values.VideoUrl = command.VideoUrl;
            await _repository.UpdateAsnyc(values);

        }
    }
}
