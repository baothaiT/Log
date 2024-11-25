using CQRS.Application.Extension.AutoMapper;
using Log.Application.Services;
using Log.Domain.Abstractions;
using Log.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

