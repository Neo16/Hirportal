using AutoMapper;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Hirportal.Model;
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

        public async Task CreateArticle(ArticleEditCreateData article)
        {
            var articleObj = Mapper.Map<Article>(article);
            context.Articles.Add(articleObj);

            await context.SaveChangesAsync();
        }
    }
}
