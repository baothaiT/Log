using Log.Contract.Entities;
using Log.Contract.Shared.Enums;

namespace Log.Contract.Shared.ExampleData;

public static class LogExampleData
{
    public static List<LogEntity> _log = new List<LogEntity>()
    {
        new LogEntity()
        {
            Id = Guid.NewGuid(),
            ComponentName = "1+ComponentName+{Message}",
            Code = LogCodeEnum.Success,
            Message = nameof(LogCodeEnum.Success),
            StartDateTime = DateTime.Now
        },
        new LogEntity()
        {
            Id = Guid.NewGuid(),
            ComponentName = "2+ComponentName+{Message}",
            Code = LogCodeEnum.Success,
            Message = nameof(LogCodeEnum.Success),
            StartDateTime = DateTime.Now
        }
    };
    
    public static Task<List<LogEntity>> GetAllExampleData()
    {
        return Task.FromResult(_log.OrderByDescending(x => x.StartDateTime)
           .ToList());
    }

    public static Task<LogEntity> CreateExampleData(LogEntity logEntity)
    {
        LogEntity log = new LogEntity()
        {
            Id = Guid.NewGuid(),
            ComponentName = logEntity.ComponentName,
            Code = logEntity.Code,
            Message = logEntity.Code == LogCodeEnum.Success ? nameof(LogCodeEnum.Success) :(!string.IsNullOrEmpty(logEntity.Message)? logEntity.Message : nameof(LogCodeEnum.BadRequest)),
            StartDateTime = DateTime.Now
        };
        _log.Add(log);
        return Task.FromResult(log);
    }

    public static Task<LogEntity> UpdateExampleData(LogEntity logEntity)
    {
        var result = _log.FirstOrDefault(x => x.Id == logEntity.Id);
        if(result != null)
        {
            result.StartDateTime = logEntity.StartDateTime;
            result.ComponentName = logEntity.ComponentName;
            result.Message = logEntity.Message;
            result.Code = logEntity.Code;
        }
        return Task.FromResult(logEntity);
    }
}
