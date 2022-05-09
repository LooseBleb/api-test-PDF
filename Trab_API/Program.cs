using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Trab_API.Validation;
using Trabs_BLL.Models;
using Trabs_DAO;
using Trabs_DAO.Interfaces;
using Trabs_DAO.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AcessDBString")));


builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped<IWorkRepository, WorkRepository>();
builder.Services.AddScoped<IMatterRepository, MatterRepository>();
builder.Services.AddTransient<IValidator<Work>, WorkValidator>();

builder.Services.AddSpaStaticFiles(diretorio =>
{
    diretorio.RootPath = "Trabs";
});


builder.Services.AddControllers()
    .AddFluentValidation()
    .AddJsonOptions(opcoes =>
    {
        opcoes.JsonSerializerOptions.IgnoreNullValues = true;
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseSpaStaticFiles();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Yago Felipe\Projects\Trabs");
    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
        spa.UseProxyToSpaDevelopmentServer($"http://localhost:4200/");
    }
});


app.Run();