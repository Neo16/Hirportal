using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Hirportal.Model;
using Hirportal.Model.MainPage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirportal.Bll.Services
{
    public class AdminArticleService : ServiceBase, IAdminArticleService
    {
        public AdminArticleService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Create(ArticleEditCreateData article)
        {
            var articleObj = Mapper.Map<Article>(article);
            context.Articles.Add(articleObj);

            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var articleEntity = await context.Articles
             .FirstOrDefaultAsync(e => e.Id == id);

            if (articleEntity != null)
            {
                context.Articles.Remove(articleEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ArticleAdminHeaderData>> Get()
        {
            return await context.Articles
              .ProjectTo<ArticleAdminHeaderData>()
              .ToListAsync();
        }

        public async Task<IEnumerable<ArticleHeaderData>> GetAll()
        {
            return await context.Articles
              .ProjectTo<ArticleHeaderData>()
              .ToListAsync();
        }

        public async Task<ArticleEditCreateData> GetByIdAsync(Guid id)
        {
            return await context.Articles
                .Where(e => e.Id == id)
                .ProjectTo<ArticleEditCreateData>()
                .FirstOrDefaultAsync();
        }

        public async Task Update(Guid id, ArticleEditCreateData article)
        {
            var articleEntity = await context.Articles
                .Include(e => e.ArticleTags)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (articleEntity != null)
            {
                var updatedArticleEntity = Mapper.Map<Article>(article);
                updatedArticleEntity.Id = articleEntity.Id;
                foreach(var articleTag in updatedArticleEntity.ArticleTags)
                {
                    articleTag.Tag = null;
                    articleTag.ArticleId = articleEntity.Id;
                }
                if (articleEntity.ArticleTags != null && articleEntity.ArticleTags.Count() > 0)
                {
                    context.ArticleTags.RemoveRange(articleEntity.ArticleTags);
                }               
                context.ArticleTags.AddRange(updatedArticleEntity.ArticleTags);

                context.Entry(articleEntity).CurrentValues.SetValues(updatedArticleEntity);
                await context.SaveChangesAsync();
            }
            else
            {
                //todo hibakezelés 
            }
        }

        public async Task UpdateMainPage(MainPageData data)
        {
            var newBlocks = data.Blocks
                .Select(block => new MainPageBlock()
                {
                    IsLeadBlock = block.IsLeadBlock,
                    Name = block.Name,
                    MainPageCells = block.Cells.Select(c => new MainPageCell()
                    {
                        ArticleId = c.Article.Id,
                        CellSize = c.CellSize,
                        DisplayId = c.DisplayIndex                            
                    })
                    .ToList()
                })
                .ToList();

            var oldBlocks = await context.MainPageBlocks.ToListAsync();
            context.MainPageBlocks.RemoveRange(oldBlocks);
            await context.SaveChangesAsync();

            context.MainPageBlocks.AddRange(newBlocks);
            await context.SaveChangesAsync();
        }
    }
}
