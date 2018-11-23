using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
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
       
        public async Task<ArticleSearchResultDto> FindAsync(ArticleFilterData filter)
        {
            var now = DateTime.Now;

            var query = context.Articles
                .Where(e =>e.PublishDate <= now)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.FreeTextParam))
            {
                query = query.Where(e => e.Title.ToUpper().Contains(filter.FreeTextParam.ToUpper())
                    || e.HtmlContent.ToUpper().Contains(filter.FreeTextParam.ToUpper()));
            }
            
            if (filter.Tags != null && filter.Tags.Count > 0)
            {
                var filteredTagIds = filter.Tags.Select(e => e.TagId);
                query = query.Where(e => e.ArticleTags.Any(f => filteredTagIds.Contains(f.TagId)));
            }          

            return new ArticleSearchResultDto() {
               Total = await query.CountAsync(),
               Articles = await query                   
                  .Skip(filter.PageStart).Take(filter.PageLength) // lapozás 
                  .ProjectTo<ArticleHeaderData>()
                  .ToListAsync()
            };
        }

        public async Task<IEnumerable<ArticleHeaderData>> GetByColumn(string column)
        {
            var now = DateTime.Now;
            //todo csak configban megadott darabot visszaadni 
            return await context.Articles
                .Where(e => e.Column.Name.ToLower() == column.ToLower())
                .Where(e => e.PublishDate <= now && e.ArchiveDate >= now)
                .ProjectTo<ArticleHeaderData>()
                .ToListAsync();
        }

        public async Task<ArticleDisplayData> GetByIdAsync(Guid articleId)
        {
            return await context.Articles
                .Where(e => e.Id == articleId)
                .Where(e => e.PublishDate <= DateTime.Now)
                .ProjectTo<ArticleDisplayData>()
                .FirstOrDefaultAsync();
        }

        public async Task<MainPageData> GetMainPage()
        {
            var mainPageData = new MainPageData();

            var blocks = await context.MainPageBlocks      
                .ProjectTo<MainPageBlockData>()                
                .ToListAsync();
            mainPageData.Blocks = blocks;

            return mainPageData;
        }
    }
}
