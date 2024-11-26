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

    public async Task<List<LogModel>> GetAll()
    {
        Task<List<LogEntity>> logReponse = _logRepository.GetAll();
        var logs = _mapper.Map<List<LogModel>>(logReponse.Result);
        
        return logs;
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

    // Method to map a list of Task<TSource> to Task<List<TDestination>>
    static async Task<List<TDestination>> MapTaskListAsync<TSource, TDestination>
        (List<Task<TSource>> taskList, IMapper mapper)
    {
        // Await all tasks to get the results
        var results = await Task.WhenAll(taskList);

        // Map the results to a list of the destination type
        return results.Select(result => mapper.Map<TDestination>(result)).ToList();
    }
}
