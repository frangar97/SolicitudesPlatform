using API;
using API.OptionSetup;
using Core.Features.Base;
using Core.Features.EstadoSolicitud.Services;
using Core.Features.Solicitud.Services;
using Core.Features.TipoSolicitud.Services;
using Core.Features.TipoUsuario.Services;
using Core.Features.Usuario.Services;
using Core.Features.Zona.Service;
using Core.Services;
using Infrastructure.Authentication;
using Infrastructure.MediaUpload;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}

        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContextPool<SolicitudesPlatformContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SolicitudPlatform"));
});

builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IZonaService,ZonaService>();
builder.Services.AddTransient<IEstadoSolicitudService, EstadoSolicitudService>();
builder.Services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddTransient<ITipoSolicitudService, TipoSolicitudService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ISolicitudService, SolicitudService>();
builder.Services.AddSingleton<IHashService, HashService>();
builder.Services.AddScoped<IMediaUpload, MediaUpload>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<SolicitudesPlatformContext>();
        context.Database.Migrate();
    }
    catch (Exception e)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error ocurred");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
