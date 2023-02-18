using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using CarShop.Service.Implementation.MappingProfiles;
using CarShop.Web.Middlewares;
using CarShop.Service.Contract;
using CarShop.Service.Implementation;
using Data.Base.Contract;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CarShopContext>(options => options.UseSqlServer(connection));

builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<CarProfile>(); });

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IBaseRepository<CarEntity>, CarsRepository>();

builder.Services.AddTransient<ICarService, CarService>();

var app = builder.Build();

app.UseMiddleware<RequestMiddleware>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
