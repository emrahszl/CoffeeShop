global using CoffeeShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var userConnnectionString = builder.Configuration.GetConnectionString("ApplicationUserDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationUserDbContextConnection' not found.");
var productConnectionString = builder.Configuration.GetConnectionString("ProductDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ProductDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationUserDbContext>(options => options.UseSqlServer(userConnnectionString));
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(productConnectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationUserDbContext>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
