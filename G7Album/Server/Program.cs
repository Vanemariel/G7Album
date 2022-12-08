#region Using globales

global using Microsoft.EntityFrameworkCore;
global using G7Album.BaseDatos.Data;
global using G7Album.BaseDatos.Entidades;
global using Microsoft.AspNetCore.Mvc;
global using G7Album.Shared.DTO_Back;
global using G7Album.Shared.DTO_Front;
global using G7Album.Shared.Models;
#endregion

using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using G7Album.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();




#region Permitimos el uso de los Cors

builder.Services.AddCors();

#endregion 

#region Desactivamos la validacion automatica del modelState para poder manipularlo manualmente

builder.Services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

#endregion

#region Conexion con la BD

var conn = builder.Configuration.GetConnectionString("con");
builder.Services.AddDbContext<BDContext>(opciones =>
    opciones.UseSqlServer(conn)
);

#endregion

#region Conexion al Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Album", Version = "v1" });
});

#endregion

#region Evite que se genere un posible ciclo de objetos a la hora de realizar consutlas a la BD

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddScoped<Lalala>(); // Incorporamos el filter 
// builder.Services.

#endregion


var app = builder.Build();

#region Problemas con los Cors 

app.UseCors(options =>
{
    options.WithOrigins("*");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

#endregion Problemas con los Cors

#region Conexion al Swagger

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Album v1");
});

#endregion


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
