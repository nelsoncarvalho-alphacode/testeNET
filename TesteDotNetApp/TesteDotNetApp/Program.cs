using Microsoft.EntityFrameworkCore;
using TesteDotNetApp.Data;
using TesteDotNetApp.Interface;
using TesteDotNetApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Banco SQL
var connectionString = "Server=DESKTOP-B16M89J\\SQLEXPRESS;Database=TesteDotNet;User Id=sa;password=mino111344;MultipleActiveResultSets=true;TrustServerCertificate=True" ;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IVaga, VagaRepository>();

builder.Services.AddTransient<ICandidato, CandidatoRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AcessoLiberado", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173", "http://localhost:3000" , "http://localhost:44390" ).AllowAnyHeader().AllowAnyMethod();
    });

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AcessoLiberado");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
