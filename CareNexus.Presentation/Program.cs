using CareNexus.Application;
using CareNexus.Application.LandingPages;
using CareNexus.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("CareNexus");
builder.Services.AddDbContext<CareNexusDbContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SignupCreateRequestHandler).Assembly));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CareNexus API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(
    options =>
    {
        options.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });

app.MapControllers();

app.Run();