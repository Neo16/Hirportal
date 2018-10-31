using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.Services
{
    public class ColumnService : ServiceBase, IColumnService
    {
        public ColumnService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ColumnData>> GetAllColumnNames()
        {
            return await context.Columns
                .ProjectTo<ColumnData>()
                .ToListAsync();
        }
    }
}
