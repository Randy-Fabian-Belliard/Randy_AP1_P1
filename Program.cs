using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Randy_AP1_P1;
using Radzen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Leer la ConnectionStrings llamada "Constr" que puse en el appsettings.json
var ConStr = builder.Configuration.GetConnectionString("ConStr");

//Inyectar el contexto para que este disponible
//En los  constructores donde lo solicitemos
builder.Services.AddDbContext<Contexto>(Op => Op.UseSqlite(ConStr));
builder.Services.AddScoped<AportesBLL>();
builder.Services.AddScoped<NotificationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
