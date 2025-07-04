using RestaurantApi.Infrastructure.Data;
using RestaurantApi.Infrastructure.Repositories;
using RestaurantApi.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
