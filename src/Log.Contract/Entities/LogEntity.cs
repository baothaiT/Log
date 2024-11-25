using Log.Contract.Shared.Enums;
using Log.Contract.Shared.ExampleData;

namespace Log.Contract.Entities;

public class LogEntity
{
    public Guid Id { get;set; }
    public DateTime StartDateTime { get;set; }
    public string ComponentName { get;set; } = string.Empty;
    public LogCodeEnum Code { get;set; }
    public string Message { get;set; } = string.Empty;
}