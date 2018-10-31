using Hirportal.Bll.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IColumnService
    {
        Task<IEnumerable<ColumnData>> GetAllColumnNames();
    }
}
