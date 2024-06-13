using Microsoft.EntityFrameworkCore;
using Vagas.Repositories;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o ApplicationContext
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

// Adiciona suporte a controllers MVC ao aplicativo
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddSession();


// Adicionando serviço de repository
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPerfilVagaRepository, PerfilVagaRepository>();
builder.Services.AddScoped<ICandidaturaRepository, CandidaturaRepository>();


var app = builder.Build();

// Configure o pipeline de solicitação
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
    
app.UseAuthorization();

app.MapRazorPages();

app.Run();
