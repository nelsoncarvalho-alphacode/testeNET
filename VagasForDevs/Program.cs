using Microsoft.EntityFrameworkCore;
using Vagas.Repositories;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Repositories;
using VagasForDevs.Services.Interfaces;
using VagasForDevs.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o ApplicationContext
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

// Adiciona suporte a controllers MVC ao aplicativo
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// Adicionando serviço de vaga
builder.Services.AddScoped<IVagaService, VagaService>();

// Adicionando serviço de repository
builder.Services.AddScoped<IVagaRepository, VagaRepository>();


builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IPerfilVagaRepository, PerfilVagaRepository>();



var app = builder.Build();

// Configure o pipeline de solicitação
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Adicione o middleware de roteamento aqui

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acesso}/{action=Index}");

app.Run();
