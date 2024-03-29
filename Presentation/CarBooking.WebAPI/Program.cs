using CarBooking.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBooking.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBooking.Application.Features.CQRS.Handlers.CarHandlers;
using CarBooking.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBooking.Application.Features.Mediator.Handlers.CarPricingHandlers;
using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.BlogInterfaces;
using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Application.Interfaces.CarPricingInterfaces;
using CarBooking.Application.Interfaces.RentACarInterfaces;
using CarBooking.Application.Interfaces.StatisticsInterfaces;
using CarBooking.Application.Interfaces.TagCloudInterfaces;
using CarBooking.Application.Services;
using CarBooking.Domain.Entities;
using CarBooking.Persistance.Context;
using CarBooking.Persistance.Repositories;
using CarBooking.Persistance.Repositories.BlogRepository;
using CarBooking.Persistance.Repositories.CarPricingRepository;
using CarBooking.Persistance.Repositories.CarRepository;
using CarBooking.Persistance.Repositories.CommentRepositories;
using CarBooking.Persistance.Repositories.RentACarRepositories;
using CarBooking.Persistance.Repositories.StatisticsRepository;
using CarBooking.Persistance.Repositories.TagCloudRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(CarBooking.Application.Interfaces.CarInterfaces.ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(CarBooking.Application.Interfaces.StatisticsInterfaces.IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));

//CQRS - About
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
//CQRS - Banner
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
//CQRS - Brand
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
//CQRS - Car
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();


//CQRS - CarPricing
builder.Services.AddScoped<GetCarPricingWithCarQueryHandler>();

builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
//CQRS - Category
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
//CQRS - Contact
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
//MediatR
builder.Services.AddApplicationServices(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
