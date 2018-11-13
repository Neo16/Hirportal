using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IAdminArticleService
    {
        Task<IEnumerable<ArticleAdminHeaderData>> Get();

        Task Create(ArticleEditCreateData article);    

        Task Update(ArticleEditCreateData column);

        Task Delete(Guid id);       
    }
}
