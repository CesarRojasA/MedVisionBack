using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persona_API_MedVision.Data;
using Persona_API_MedVision.Interfaces;
using Persona_API_MedVision.Repository;
using Persona_API_MedVision.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Use Json
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

//Injeccion de dependencias
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddSingleton(builder.Configuration);


//Add inyeccion de DBContext Service
builder.Services.AddDbContext<SqlDbContext_PruebaMedVisionDB>(
options =>
{
    string connectionString = builder.Configuration.GetConnectionString("SQLCSPruebaMedVisionDB");
    options.UseSqlServer(connectionString);
});


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
