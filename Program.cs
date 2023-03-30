using Microsoft.EntityFrameworkCore;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Repositories.Contracts;
using PruebaAdventureWorks.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AdventureWorksContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

//builder.Services.AddScoped<IGenericRepository, GenericRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
