using AutoMapper;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Exceptions;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Hirportal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.Services
{
    public class AdminColumnService : ServiceBase, IAdminColumnService
    {

        public AdminColumnService(ApplicationDbContext context) : base(context)
        {
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

        public async Task<Guid> Create(ColumnData column)
        {
            var columnObj = Mapper.Map<Column>(column);
            context.Columns.Add(columnObj);
            await context.SaveChangesAsync();
            return columnObj.Id;
        }

        public async Task Update(ColumnData column)
        {
            var columnEntity = await context.Columns
              .FirstOrDefaultAsync(e => e.Id == column.Id);

            if (columnEntity != null)
            {
                columnEntity.Name = column.Name;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new BusinessLogicException("A keresett rovat nem található.") { ErrorCode = ErrorCode.InvalidArgument };
            }
        }
    }
}
