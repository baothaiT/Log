using AutoMapper;
using Log.Domain.Abstractions;
using Log.Domain.Models;

namespace Log.Application.Services;

public interface ILogService
{
    public Task<List<LogModel>> GetAll();
    public Task Create(LogModel log);
    public Task<LogModel> Update(LogModel log);

}