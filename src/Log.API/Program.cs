using AutoMapper;
using CQRS.Application.Extension.AutoMapper;
using Log.Application.Services;
using Log.Domain.Abstractions;
using Log.Persistence;
using Log.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SeverConnection"), b => b.MigrationsAssembly("Log.API")));
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application
builder.Services.AddScoped<ILogService, LogService>();

// Persistence
builder.Services.AddScoped<ILogRepository, LogRepository>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(LogProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

