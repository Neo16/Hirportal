using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleSearchResultDto
    {
        public int Total { get; set; }
        public IEnumerable<ArticleHeaderData> Articles { get; set; }
    }
}
