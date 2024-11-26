using AutoMapper;
using Log.Contract.Entities;
using Log.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Extension.AutoMapper;

public class LogProfile : Profile
{
    public LogProfile()
    {
        CreateMap<LogEntity, LogModel>();

        CreateMap<LogModel, LogEntity>();
    }
}