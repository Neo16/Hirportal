using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IAdminArticleService
    {
        Task CreateArticle(ArticleEditCreateData article);
    }
}
