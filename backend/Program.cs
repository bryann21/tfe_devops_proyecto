using Microsoft.EntityFrameworkCore;
using MiProyectoWeb.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ===================== CONFIGURAR CONEXIÓN A LA BD =====================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===================== CONFIGURAR CONTROLADORES Y SWAGGER =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TFM_API",
        Version = "v1",
        Description = "API para el sistema de gestión de clientes"
    });
});

// ===================== HABILITAR CORS PARA REACT =====================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// ===================== HABILITAR SWAGGER EN PRODUCCIÓN =====================
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TFM_API v1");
});


// ===================== CORS =====================
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
