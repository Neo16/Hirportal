using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IColumnService
    {
        Task<IEnumerable<ColumnData>> Get();

        Task Create(ColumnData column);

        Task Update(Guid id, ColumnData column);

        Task Delete(Guid id);
    }
}
