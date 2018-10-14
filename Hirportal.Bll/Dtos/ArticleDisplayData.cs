using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleDisplayData : ArticleHeaderData
    {
        public string HtmlContent { get; set; }

        public string AuthorName { get; set; }
    }
}
