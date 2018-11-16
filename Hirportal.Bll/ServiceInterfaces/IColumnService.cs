using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IColumnService
    {
        Task<IEnumerable<ColumnData>> Get();

        Task<Guid> Create(ColumnData column);

        Task Update(ColumnData column);

        Task Delete(Guid id);
    }
}
