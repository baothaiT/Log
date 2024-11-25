using AutoMapper;
using Log.Contract.Entities;
using Log.Domain.Abstractions;
using Log.Domain.Models;

namespace Log.Application.Services;

public class LogService: ILogService
{
    private readonly ILogRepository _logRepository;
    private readonly IMapper _mapper;

    public LogService(ILogRepository logRepository, IMapper mapper)
    {
        _logRepository = logRepository;
        _mapper = mapper;
    }

    public Task Create(LogModel log)
    {
        LogEntity logEntity = new LogEntity();
        _mapper.Map(log, logEntity);   
        _logRepository.Create(logEntity);
        return Task.CompletedTask;
    }

    public Task<List<LogModel>> GetAll()
    {
        List<LogModel> logs = new List<LogModel>();
        var logReponse = _logRepository.GetAll();
        _mapper.Map(logReponse, logs);    
        return Task.FromResult(logs) ;
    }

    public Task<LogModel> Update(LogModel log)
    {
        LogEntity logEntity = new LogEntity();
        _mapper.Map(log, logEntity);   
        var logReponse = _logRepository.Update(logEntity);

        LogModel logModel = new LogModel();
        _mapper.Map(logReponse, logModel);   
        return Task.FromResult(logModel);
    }
}
