﻿using CarBooking.Application.Features.CQRS.Queries.AboutQueries;
using CarBooking.Application.Features.CQRS.Queries.BannerQueries;
using CarBooking.Application.Features.CQRS.Results.AboutResults;
using CarBooking.Application.Features.CQRS.Results.BannerResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId=values.BannerId,
                Description=values.Description,
                Title=values.Title,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl
                

            };
        }
    }
}
