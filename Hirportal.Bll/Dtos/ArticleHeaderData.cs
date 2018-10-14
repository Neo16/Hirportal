using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleHeaderData
    {
        public Guid  Id { get; set; }

        public string Title { get; set; }

        public string CoverImageUrl { get; set; }

        public string  ThumbnailContent { get; set; }
    }
}
