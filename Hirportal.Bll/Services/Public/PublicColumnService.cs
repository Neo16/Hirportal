using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Exceptions;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Hirportal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.Services
{
    public class PublicColumnService : ServiceBase, IPublicColumnService
    {
        public PublicColumnService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Guid> Create(ColumnData column)
        {
            var columnObj = Mapper.Map<Column>(column);
            context.Columns.Add(columnObj);
            await context.SaveChangesAsync();
            return columnObj.Id;
        }
        

        public async Task<IEnumerable<ColumnData>> Get()
        {
            return await context.Columns
                .ProjectTo<ColumnData>()
                .ToListAsync();
        }       
    }
}
