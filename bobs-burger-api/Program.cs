using bobs_burger_api.Data;
using bobs_burger_api.Endpoints;
using bobs_burger_api.Models.Favourites;
using bobs_burger_api.Models.Ingredients;
using bobs_burger_api.Models.Orders;
using bobs_burger_api.Models.Products;
using bobs_burger_api.Models.Users;
using bobs_burger_api.Repository;
using bobs_burger_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        builder => builder.WithOrigins("http://localhost:5173", "http://localhost:5174")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services
.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
options.SignIn.RequireConfirmedAccount = false;
options.User.RequireUniqueEmail = true;
options.Password.RequireDigit = false;
options.Password.RequiredLength = 6;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequireUppercase = false;
})
// enaable authorization using Roles
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<BobsBurgerContext>();

var validIssuer = builder.Configuration.GetValue<string>
("JwtTokenSettings:ValidIssuer");
var validAudience = builder.Configuration.GetValue<string>
("JwtTokenSettings:ValidAudience");

var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme =
JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme =
    JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new
    TokenValidationParameters()
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = validIssuer,
        ValidAudience = validAudience,
        IssuerSigningKey = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(symmetricSecurityKey)
    ),
    };
});

builder.Services.AddDbContext<BobsBurgerContext>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<Favourite>, Repository<Favourite>>();
builder.Services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
builder.Services.AddScoped<TokenService, TokenService>();
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
app.ConfigureAuthEndpoints();
app.UseCors("AllowLocalhost5173"); // Enable CORS middleware
app.UseAuthentication();
app.UseAuthorization();
app.Run();
