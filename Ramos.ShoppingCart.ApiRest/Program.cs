using Microsoft.EntityFrameworkCore;
using Ramos.ShoppingCart.ApiRest.Configurations;
using Ramos.ShoppingCart.Domain.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppingCartDbContext>(options => options.UseSqlServer("name=DbConnetion"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCoreServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
