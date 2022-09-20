global using Microsoft.EntityFrameworkCore;
global using G7Album.BaseDatos.Data;
global using G7Album.BaseDatos.Entidades;
global using Microsoft.AspNetCore.Mvc;

using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


/* Problemas con los Cors */
builder.Services.AddCors();
/* Problemas con los Cors */

var conn = builder.Configuration.GetConnectionString("con");
builder.Services.AddDbContext<BDContext>(opciones =>
    opciones.UseSqlServer(conn)
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Album", Version = "v1" });
});


#region Evite que se genere un posible ciclo de objetos a la hora de realizar consutlas a la BD

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

#endregion


var app = builder.Build();


/* Problemas con los Cors */

app.UseCors(options =>
{
    options.WithOrigins("*");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

/* Problemas con los Cors */


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Album v1"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
