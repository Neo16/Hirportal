using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
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

        Task Update(Guid id, ArticleEditCreateData article);

        Task Delete(Guid id);

        Task<ArticleEditCreateData> GetByIdAsync(Guid id);

        Task<IEnumerable<ArticleHeaderData>> GetAll();

        Task UpdateMainPage(MainPageData data);
    }
}
