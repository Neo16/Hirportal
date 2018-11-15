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
    public class ColumnService : ServiceBase, IColumnService
    {
        public ColumnService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Create(ColumnData column)
        {
            var columnObj = Mapper.Map<Column>(column);
            context.Columns.Add(columnObj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {

            bool columnsHasArticles = await context.Articles
                .AnyAsync(e => e.ColumnId == id);
            if (columnsHasArticles)
            {
                throw new BusinessLogicException("A rovat nem törölhető, mert cikkek tartoznak hozzá.") { ErrorCode = ErrorCode.InvalidArgument };
            }

            var columnEntity = await context.Columns
              .FirstOrDefaultAsync(e => e.Id == id);

            if (columnEntity != null)
            {
                context.Columns.Remove(columnEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ColumnData>> Get()
        {
            return await context.Columns
                .ProjectTo<ColumnData>()
                .ToListAsync();
        }

        public async Task Update(Guid id, ColumnData column)
        {
            var columnEntity = await context.Columns
              .FirstOrDefaultAsync(e => e.Id == id);

            if (columnEntity != null)
            {
                var updatedcolumnEntity = Mapper.Map<Column>(column);
                context.Entry(columnEntity).CurrentValues.SetValues(updatedcolumnEntity);
                await context.SaveChangesAsync();
            }
            else
            {
                //todo hibakezelés 
            }
        }
    }
}
