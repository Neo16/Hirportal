using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IPublicColumnService
    {
        Task<IEnumerable<ColumnData>> Get();      
    }
}
