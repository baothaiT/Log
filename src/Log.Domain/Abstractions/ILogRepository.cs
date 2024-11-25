
using Log.Contract.Entities;

namespace Log.Domain.Abstractions;

public interface ILogRepository
{
    public Task<List<LogEntity>> GetAll();
    public Task<LogEntity> Create(LogEntity logEntity);
    public Task<LogEntity> Update(LogEntity logEntity);
}