using FluentValidation;
using FluentValidation.AspNetCore;
using RestaurantApi.API.Middleware;
using RestaurantApi.API.Validators;
using RestaurantApi.Application.Services;
using RestaurantApi.Infrastructure.Data;
using RestaurantApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<MenuItemDtoValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// MongoDB connection
builder.Services.AddSingleton(sp =>
{
    var config = builder.Configuration;
    return new MongoContext(
        config["MongoDb:ConnectionString"],
        config["MongoDb:DatabaseName"]
    );
});


builder.Services.AddScoped<MenuItemRepository>();
builder.Services.AddScoped<MenuItemService>();

// Health checks
builder.Services.AddHealthChecks();
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
