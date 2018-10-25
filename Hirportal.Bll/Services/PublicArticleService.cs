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

        //Tag-kereső oldal külön. 
        public async Task<IEnumerable<ArticleHeaderData>> FindAsync(ArticleFilterData filter)
        {
            var query = context.Articles
                .AsQueryable();

            if (filter.ColumnName != null)
            {
                query = query.Where(e => e.Column.Name.ToLower() == filter.ColumnName.ToLower());
            }
            if (filter.Tags != null && filter.Tags.Count > 0)
            {
                query = query.Where(e => e.ArticleTags.Any(f => filter.Tags.Contains(f.Tag.Value.ToLower())));

            }
 
            return await query
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

        public async Task<MainPageData> GetMainPage()
        {
            var mainPageData = new MainPageData();

            var blocks = await context.MainPageBlocks      
                .ProjectTo<MainPageBlockData>()                
                .ToListAsync();            

            var subBlocks = blocks
                .Where(e => e.IsLeadBlock == false)            
                .ToList();
            
            var leadBlock  = blocks
               .Where(e => e.IsLeadBlock == true)             
               .FirstOrDefault();
            
            mainPageData.Blocks = subBlocks;
            mainPageData.LeadBlock = leadBlock;

            return mainPageData;
        }
    }
}
