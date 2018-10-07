using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hirportal.Bll
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfiles(typeof(AutoMapperConfiguration).Assembly));
        }      
    }
}
