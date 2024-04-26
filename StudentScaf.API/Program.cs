using Microsoft.EntityFrameworkCore;
using StudentScaf.Business;
using StudentScaf.Business.Interfaces;
using StudentScaf.Entity.Models;
using System.ComponentModel;
using StudentScaf.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<DbContext, StudentScaffoldContext>();
builder.Services.AddScoped<IStudentScafRepository, StudentScafRepository>();
builder.Services.AddScoped<IStudentScafBusiness, StudentScafBusiness>();

//Connection Injection
builder.Services.AddDbContext<StudentScaffoldContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentScafConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();