using ITControl.Application.Auth.Interfaces;
using ITControl.Application.Auth.Services;
using ITControl.Communication.Shared.Converters;
using ITControl.CrossCutting.IoC;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new GuidConverter());
    options.JsonSerializerOptions.Converters.Add(new GuidNullableConverter());
    options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
    options.JsonSerializerOptions.Converters.Add(new DateOnlyNullableConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyNullableConverter());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        config => config.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddInfrastructureApi(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITControl", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = @"JWT Authorization header using the Bearer scheme.
                    Enter 'Bearer'[space].Example: \'Bearer 12345abcdef\'",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            []
        }
    });
});

builder.Services.AddSingleton<ITokenService>(new TokenService());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExceptionFilter));
    //options.Filters.Add(typeof(PermissionsFilter));
});

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = new List<string>();
        actionContext.ModelState.Values.ToList().ForEach(v => v.Errors.ToList().ForEach(e => errors.Add(e.ErrorMessage)));

        // Create a custom error response object
        var customErrorResponse = new
        {
            StatusCode = 400,
            Message = "Validation Failed",
            Errors = errors
        };

        return new BadRequestObjectResult(customErrorResponse);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();