using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IAdminColumnService
    {
        Task<Guid> Create(ColumnData column);

        Task Update(ColumnData column);

        Task Delete(Guid id);
    }
}
