
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Contract.Entities;
using Log.Contract.Shared.ExampleData;
using Log.Domain.Abstractions;

namespace Log.Persistence.Repositories;

public class LogRepository : ILogRepository
{
    private readonly AppDbContext _context;
    public LogRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<LogEntity> Create(LogEntity logEntity)
    {
        return LogExampleData.CreateExampleData(logEntity);
    }

    public Task<List<LogEntity>> GetAll()
    {
        return LogExampleData.GetAllExampleData();
    }

    public Task<LogEntity> Update(LogEntity logEntity)
    {
        return LogExampleData.UpdateExampleData(logEntity);
    }
}