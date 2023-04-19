using System.Data;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Core.Services;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
const string policyPermissionOrigins = "_myAllowSpecificOrigins";

var key = Encoding.ASCII.GetBytes("A3A670475B40469994AECC8610E3B4EA");

#region Auth

builder.Services.AddAuthentication
(
    o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion


builder.Services.AddSingleton<IDbConnection>(new SqlConnection(builder.Configuration.GetSection("AppConfiguration")
    .GetSection("ConnectionString").Value));

builder.Services.AddSingleton<IAgendaServices, AgendaServices>();
builder.Services.AddTransient<IAgendaRepository, AgendaRepository>();

builder.Services.AddSingleton<IAuthServices, AuthServices>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();

builder.Services.AddSingleton<IAvisosServices, AvisosServices>();
builder.Services.AddTransient<IAvisosRepository, AvisosRepository>();

builder.Services.AddSingleton<IConsultoresServices, ConsultoresService>();
builder.Services.AddTransient<IConsultorRespository, ConsultorRespository>();

builder.Services.AddTransient<ItenRatServiceses, ItenRatServiceses>();
builder.Services.AddTransient<IItenRatRepository, ItenRatRepository>();

builder.Services.AddSingleton<IModulosServices, ModulosServices>();
builder.Services.AddTransient<IModulosRepository, ModulosRepository>();

builder.Services.AddSingleton<IServicosServices, ServicosServices>();
builder.Services.AddTransient<IServicosRepository, ServicosRepository>();

builder.Services.AddSingleton<IRatService, RatServices>();
builder.Services.AddTransient<IRatRepository, RatRepository>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(options =>
    {
        var jwtSecurityScheme = new OpenApiSecurityScheme()
        {
            Scheme = "bearer",
            BearerFormat = "JWT",
            Name = "JWT authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Description = "Insira o Token Abaixado",

            Reference = new OpenApiReference()
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { jwtSecurityScheme, Array.Empty<string>() }
        });
    }
);

#endregion

#region Cors

builder.Services.AddCors(o =>
{
    o.AddPolicy(policyPermissionOrigins, policyBuilder =>
    {
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyOrigin();
    });
});

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var ex = context.Features.Get<IExceptionHandlerFeature>();
        if (ex != null)
        {
            await context.Response.WriteAsJsonAsync(
                new { ex.Error.Message, ex.Error.Data, ex.Endpoint, ex.RouteValues, ex.Path });
        }
        else
        {
            await context.Response.WriteAsJsonAsync(new { ex?.Error.Message });
        }
    });
});

app.UseCors(policyPermissionOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();