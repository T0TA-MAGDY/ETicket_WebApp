using Microsoft.EntityFrameworkCore;
using ticketer.Models;
using ticketer.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticketer.Data.Static;
using ticketer.Data.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
    

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHostedService<ShowtimesCleanupService>();


var app = builder.Build();
app.UseAuthentication(); 
app.UseAuthorization();
AppDbInitializer.Seed(app); // for static data
await AppDbInitializer.SeedUsersAndRolesAsync(app); // for users and roles


// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
