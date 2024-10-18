using AulaEntityFramework.Models;
using AulaEntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString =
    builder
    .Configuration["AulaEntityFramework:ConnectionString"];

// Fazemos a configura��o do DbContext com
// o banco de dados espec�fico, neste caso
// o SQLServer
builder.Services.AddDbContext<MyDbContext>(
    o => o.UseSqlServer(connString)
);

//Regristro dos servi�os relacionados � camada de
//acesso ao reposit�rio de dados
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pessoas}/{action=Index}/{id?}");

app.Run();
