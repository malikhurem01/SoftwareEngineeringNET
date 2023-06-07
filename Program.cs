using Microsoft.EntityFrameworkCore;
using ResumeMaker.API.Extensions;
using ResumeMaker.Data;
using ResumeMaker.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();
builder.Services.RegisterControllers();
builder.Services.RegisterIdentityAuthentication(builder.Configuration);
builder.Services.RegisterDBContext(builder.Configuration);
builder.Services.RegisterJWTAuthentication(builder.Configuration);
builder.Services.RegisterAutoMapper();
builder.Services.RegisterCors(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseCors(RegisterCorsExtension.origin);

app.UseAuthorization();

app.MapControllers();

app.Run();
