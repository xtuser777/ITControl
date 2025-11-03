using System.Text;
using ITControl.Application.Auth.Interfaces;
using ITControl.Application.Auth.Services;
using ITControl.Application.Divisions.Interfaces;
using ITControl.CrossCutting.IoC;
using ITControl.Presentation.Appointments.Interfaces;
using ITControl.Presentation.Appointments.Views;
using ITControl.Presentation.Auth.Interfaces;
using ITControl.Presentation.Auth.Views;
using ITControl.Presentation.Calls.Interfaces;
using ITControl.Presentation.Calls.Views;
using ITControl.Presentation.Contracts.Interfaces;
using ITControl.Presentation.Contracts.Views;
using ITControl.Presentation.Departments.Interfaces;
using ITControl.Presentation.Departments.Views;
using ITControl.Presentation.Divisions.Interfaces;
using ITControl.Presentation.Divisions.Views;
using ITControl.Presentation.Equipments.Interfaces;
using ITControl.Presentation.Equipments.Views;
using ITControl.Presentation.KnowledgeBases.Interfaces;
using ITControl.Presentation.KnowledgeBases.Views;
using ITControl.Presentation.Notifications.Interfaces;
using ITControl.Presentation.Notifications.Views;
using ITControl.Presentation.Pages.Interfaces;
using ITControl.Presentation.Pages.Views;
using ITControl.Presentation.Positions.Interfaces;
using ITControl.Presentation.Positions.Views;
using ITControl.Presentation.Roles.Interfaces;
using ITControl.Presentation.Roles.Views;
using ITControl.Presentation.Shared.Converters;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Supplements.Interfaces;
using ITControl.Presentation.Supplements.Views;
using ITControl.Presentation.SupplementsMovements.Interfaces;
using ITControl.Presentation.SupplementsMovements.Views;
using ITControl.Presentation.Systems.Interfaces;
using ITControl.Presentation.Systems.Views;
using ITControl.Presentation.Treatments.Interfaces;
using ITControl.Presentation.Treatments.Views;
using ITControl.Presentation.Units.Interfaces;
using ITControl.Presentation.Units.Views;
using ITControl.Presentation.Users.Interfaces;
using ITControl.Presentation.Users.Views;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
builder.Services.AddScoped<IAuthView, AuthView>();
builder.Services.AddScoped<IAppointmentsView, AppointmentsView>();
builder.Services.AddScoped<ICallsView, CallsView>();
builder.Services.AddScoped<ICallsStatusesView, CallsStatusesView>();
builder.Services.AddScoped<ICallsReasonsView, CallsReasonsView>();
builder.Services.AddScoped<IContractsView, ContractsView>();
builder.Services.AddScoped<IDepartmentsView, DepartmentsView>();
builder.Services.AddScoped<IPositionsView, PositionsView>();
builder.Services.AddScoped<IPagesView, PagesView>();
builder.Services.AddScoped<IRolesView, RolesView>();
builder.Services.AddScoped<IUsersView, UsersView>();
builder.Services.AddScoped<IDivisionsView, DivisionsView>();
builder.Services.AddScoped<IUnitsView, UnitsView>();
builder.Services.AddScoped<ISystemsView, SystemsView>();
builder.Services.AddScoped<IEquipmentsView, EquipmentsView>();
builder.Services.AddScoped<IEquipmentsTypesView, EquipmentsTypesView>();
builder.Services.AddScoped<ITreatmentsView, TreatmentsView>();
builder.Services.AddScoped<ITreatmentsStatusesView, TreatmentsStatusesView>();
builder.Services.AddScoped<ITreatmentsTypesView, TreatmentsTypesView>();
builder.Services.AddScoped<INotificationsView, NotificationsView>();
builder.Services.AddScoped<INotificationsTypesView, NotificationsTypesView>();
builder.Services.AddScoped<INotificationsReferencesView, NotificationsReferencesView>();
builder.Services.AddScoped<ISupplementsView, SupplementsView>();
builder.Services.AddScoped<ISupplementsTypesView, SupplementsTypesView>();
builder.Services.AddScoped<ISupplementsMovementsView, SupplementsMovementsView>();
builder.Services.AddScoped<IKnowledgeBasesView, KnowledgeBasesView>();

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