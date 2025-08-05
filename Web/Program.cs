using Microsoft.EntityFrameworkCore;
using Infrastructure.UnitOfWork;
using Infrastructure.Data;
using System;
using Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// add IUnitOfWork and IGenericRepository services  
builder.Services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
//https://www.youtube.com/watch?v=pqtsibzqtZw&t=1s -> 1:19 mnute