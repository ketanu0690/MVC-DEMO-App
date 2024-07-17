using DemoMVCApplication.Models.Dto;
using DemoMVCApplication.Models.Entity;
using DemoMVCApplication.Repository.DBContext;
using DemoMVCApplication.services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var ConnString = builder.Configuration.GetConnectionString("DBConnection");
// Register the DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnString));

// Configure AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<User, UserDto>().ReverseMap();
});

//Wireup services with concrete class
builder.Services.RegisterDependencies();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
