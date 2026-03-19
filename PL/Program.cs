using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("JguevaraDiciembre") ??
     throw new InvalidOperationException("Connection string 'JguevaraDiciembre'" +
    " not found.");

builder.Services.AddDbContext<DL.JguevaraDiciembreContext>(options =>
    options.UseSqlServer(conString));

builder.Services.AddScoped<BL.Materia>();  // crear una instancia por peticion HTTP
//builder.Services.AddSingleton(); // Crea una unica instancia para todo el proyecto
//builder.Services.AddTransient(); // Crear una instancia pero esta enfocada a metodos especifico

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Materia}/{action=GetAll}/{id?}");

app.Run();
