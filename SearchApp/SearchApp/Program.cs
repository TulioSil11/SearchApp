using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SearchApp.Interfaces.Repositories;
using SearchApp.Interfaces.Services;
using SearchApp.Models;
using SearchApp.Models.Context;
using SearchApp.Repositories;
using SearchApp.SeedData;
using SearchApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options => options.UseSqlite("Data Source=Teste.db"));
builder.Services.AddTransient<SeedService>();

builder.Services.AddScoped<IConsignedCreditFormService, ConsignedCreditFormService>();
builder.Services.AddScoped<IRepositoryBase<Person>, RepositoryBase<Person>>();
builder.Services.AddScoped<IRepositoryBase<Response>, RepositoryBase<Response>>();
builder.Services.AddScoped<IRepositoryBase<Question>, RepositoryBase<Question>>();

var app = builder.Build();

var seedData = app.Services.GetService<SeedService>();
seedData.Seed();

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
