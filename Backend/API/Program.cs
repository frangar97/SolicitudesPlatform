using API;
using Core.Features.Base;
using Core.Features.EstadoSolicitud.Services;
using Core.Features.TipoSolicitud.Services;
using Core.Features.TipoUsuario.Services;
using Core.Features.Usuario.Services;
using Core.Features.Zona.Service;
using Core.Services;
using Infrastructure.MediaUpload;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddSingleton<IHashService, HashService>();
builder.Services.AddScoped<IMediaUpload, MediaUpload>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
