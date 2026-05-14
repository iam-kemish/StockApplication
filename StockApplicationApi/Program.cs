using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using StockApplicationApi.Database;
using StockApplicationApi.Mapper;
using StockApplicationApi.Models;
using StockApplicationApi.Repositary.CommentRepositary;
using StockApplicationApi.Repositary.StockRepositary;
using StockApplicationApi.Seeders;
using StockApplicationApi.Services.AuthService;
using StockApplicationApi.Services.CommentServices;
using StockApplicationApi.Services.RedisService;
using StockApplicationApi.Services.StockServices;
using StockApplicationApi.Services.Token;
using StockApplicationApi.Validators.Auth;
using StockApplicationApi.Validators.Stocks;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVICES REGISTRATION ---
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<StockCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StockUpdateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();


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
        ),
       
        ValidateLifetime = true, 
        ClockSkew = TimeSpan.Zero 
    };
   
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock Application API", Version = "v1" });

    // 1. Define the Security Scheme (How the token looks)
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    // 2. Apply the Security Requirement (Make it global or per-endpoint)
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
            new string[]{}
        }
    });
});
var redisConnection = builder.Configuration.GetConnectionString("RedisConnection");
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection!));
builder.Services.AddAutoMapper(typeof(MapConfig));
builder.Services.AddScoped<IStock, StockRepo>();
builder.Services.AddScoped<IStockService, StockClass>();
builder.Services.AddScoped<IComment, CommentClass>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRedisService, RedisClass>();
builder.Services.AddScoped<IdentitySeeder>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapOpenApi(); 

    app.UseSwaggerUI(options =>
    {
        // Add the forward slash here!
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock API v1");
    });
}
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IdentitySeeder>();
    await seeder.SeedAdminAsync();

}
app.UseMiddleware<GlobalException>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();