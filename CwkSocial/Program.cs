
using CwkSocial.Api.Extensions;
using CwkSocial.DataAcces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices(typeof(Program));

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer("Server=localhost;Database=CwkSocial;Trusted_connection=true;TrustServerCertificate=true");
});

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));

app.Run();
