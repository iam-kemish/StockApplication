using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using StockApplicationApi.Database;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.AuthService;
using StockApplicationApi.Services.CommentServices;
using StockApplicationApi.Services.RedisService;
using StockApplicationApi.Services.StockServices;
using StockApplicationApi.Services.Token;
using StockApplicationApi.Validators.Stocks;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICES REGISTRATION ---
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<StockCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StockUpdateDtoValidator>();

// Database & Identity
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequiredUniqueChars = 1;
}).AddEntityFrameworkStores<AppDbContext>();

// Authentication
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

builder.Services.AddAutoMapper(typeof(MapConfig));
builder.Services.AddScoped<IStock, StockRepo>();
builder.Services.AddScoped<IStockService, StockClass>();
builder.Services.AddScoped<IComment, CommentClass>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<IRedisService, RedisClass>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 

    app.UseSwaggerUI(options =>
    {
        // Add the forward slash here!
        options.SwaggerEndpoint("/openapi/v1.json", "Stock API v1");
    });
}

app.UseMiddleware<GlobalException>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();