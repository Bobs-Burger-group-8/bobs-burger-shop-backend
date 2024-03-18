using bobs_burger_api.Data;
using bobs_burger_api.Endpoints;
using bobs_burger_api.Models;
using bobs_burger_api.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BobsBurgerContext>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureProductEndpoint();
app.Run();
