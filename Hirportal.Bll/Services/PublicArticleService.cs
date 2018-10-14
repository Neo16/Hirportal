using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirportal.Bll.Services
{
    public class PublicArticleService : ServiceBase, IPublicArticleService
    {
        public PublicArticleService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ArticleHeaderData>> FindAsync(ArticleFilterData filter)
        {
            //todo null checkek 
            return await context.Articles
              .Where(e => e.Column.Name.ToLower() == filter.ColumnName.ToLower())
              .Where(e => e.ArticleTags.Any(f => filter.Tags.Contains(f.Tag.Value.ToLower())))
              .ProjectTo<ArticleHeaderData>()
              .ToListAsync();
        }

        public async Task<IEnumerable<ArticleHeaderData>> GetByColumn(string column)
        {            
            //todo csak configban megadott darabot visszaadni 
            return await context.Articles
                .Where(e => e.Column.Name.ToLower() == column.ToLower())
                .ProjectTo<ArticleHeaderData>()
                .ToListAsync();
        }

        public async Task<ArticleDisplayData> GetByIdAsync(Guid articleId)
        {
            return await context.Articles
                .Where(e => e.Id == articleId)
                .ProjectTo<ArticleDisplayData>()
                .FirstOrDefaultAsync();
        }
    }
}
