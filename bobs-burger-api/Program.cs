using bobs_burger_api.Data;
using bobs_burger_api.Endpoints;
using bobs_burger_api.Models;
using bobs_burger_api.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BobsBurgerContext>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<Favourite>, Repository<Favourite>>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureProductEndpoint();
app.ConfigureIngredientEndpoint();
app.ConfigureUserEndpoint();
app.ConfigureOrderEndpoint();
app.ConfigureFavouriteEndpoint();
app.Run();
