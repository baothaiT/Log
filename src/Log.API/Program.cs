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

// Add CORS services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("https://example.com") // Allow specific origin
              .AllowAnyHeader()                  // Allow any header
              .AllowAnyMethod();                 // Allow any HTTP method (GET, POST, etc.)
    });

    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()                  // Allow all origins
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

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
app.UseRouting();

// Enable CORS globally (for all endpoints)
app.UseCors("AllowSpecificOrigins"); // or "AllowAll" based on your use case
app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();
app.Run();

