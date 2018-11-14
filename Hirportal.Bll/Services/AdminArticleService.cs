﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Hirportal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task Update(Guid id, ArticleEditCreateData article)
        {
            var articleEntity = await context.Articles
                .FirstOrDefaultAsync(e => e.Id == id);

            if (articleEntity != null)
            {
                var updatedArticleEntity = Mapper.Map<Article>(article);
                context.Entry(articleEntity).CurrentValues.SetValues(updatedArticleEntity);
                await context.SaveChangesAsync();
            }
            else
            {
                //todo hibakezelés 
            }
        }
    }
}
