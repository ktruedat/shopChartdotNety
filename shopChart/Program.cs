using Microsoft.EntityFrameworkCore;
using shopChart.Data;
using shopChart.Logic;
using shopChart.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<ICategoryRepositorySubset, CategoryRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var ctx = services.GetRequiredService<ProductContext>();
    ctx.Database.Migrate();
    if (app.Environment.IsDevelopment())
    {
        ctx.SeedInitialData();
    }
}

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
app.UseExceptionHandler("/Home/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();