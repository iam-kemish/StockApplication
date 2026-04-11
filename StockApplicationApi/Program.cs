using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using StockApplicationApi.Database;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Services.CommentServices;
using StockApplicationApi.Services.StockServices;
using StockApplicationApi.Validators.Stocks;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


builder.Services.AddValidatorsFromAssemblyContaining<StockCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StockUpdateDtoValidator>();


builder.Services.AddOpenApi();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        ),
       
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MapConfig));

// Your services
builder.Services.AddScoped<IStock, StockRepo>();
builder.Services.AddScoped<IStockService, StockClass>();
builder.Services.AddScoped<IComment, CommentClass>();
builder.Services.AddScoped<ICommentService,CommentService>();
var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<GlobalException>();
    app.MapOpenApi();           // usually before Scalar
    app.MapScalarApiReference(); // nice for dev docs
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();