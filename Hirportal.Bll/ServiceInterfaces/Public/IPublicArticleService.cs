﻿using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IPublicArticleService
    {
        Task<ArticleDisplayData> GetByIdAsync(Guid id);

        Task<ArticleSearchResultDto> FindAsync(ArticleFilterData filter);

        Task<IEnumerable<ArticleHeaderData>> GetByColumn(string column);

        Task<MainPageData> GetMainPage();
    }
}
