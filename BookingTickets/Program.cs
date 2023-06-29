using BookingTickets.Areas.User.Controllers;
using BookingTickets.Converteds;
using BookingTickets.Interfaces;
using BookingTickets.Models;
using BookingTickets.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddScoped<IInvoiceCarService, InvoiceCarImpl>();

builder.Services.AddScoped<IChairCarService, ChairCarServiceImpl>();

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionStrings));

builder.Services.AddScoped<ICarService, CarServiceImpl>();

builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>();

builder.Services.AddScoped<IShippingService, ShippingServiceImpl>();

builder.Services.AddScoped<IDiscountService, DiscountServiceImpl>();

builder.Services.AddScoped<IinvoiceShippingService, InvoiceShippingImpl>();

builder.Services.AddCors();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverted());
});

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials()
);

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.UseStaticFiles();

app.Run();