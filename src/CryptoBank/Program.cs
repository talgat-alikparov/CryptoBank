using CryptoBank.Database;
using CryptoBank.Features.News.Registration;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CryptoBankDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CryptoBankDbContext")));

builder.Services.AddMediatR(cfg => cfg
    .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddFastEndpoints();

// Features
builder.AddNews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapFastEndpoints();

app.Run();
