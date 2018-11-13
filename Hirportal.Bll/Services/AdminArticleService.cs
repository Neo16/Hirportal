using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticleAdminHeaderData>> Get()
        {
            return await context.Articles
              .ProjectTo<ArticleAdminHeaderData>()
              .ToListAsync();
        }

        public Task Update(ArticleEditCreateData column)
        {
            throw new NotImplementedException();
        }
    }
}
