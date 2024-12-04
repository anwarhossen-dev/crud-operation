using GTR.DataAccess;
using GTR.DataAccess.Repositories;
using GTR.DataAccess.Repositories.Implement;
using GTR.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GTRDBContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("Mycon")).UseLowerCaseNamingConvention();
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
// Program.cs (for .NET 6 or later)
builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
// Register your services in DI container
builder.Services.AddTransient<IDesignationRepo, DesignationRepo>();


//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
////builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
//builder.Services.AddTransient<IDesignationRepo,DesignationRepo>();
//builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();





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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");




app.MapControllerRoute(
    name: "GTR",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
