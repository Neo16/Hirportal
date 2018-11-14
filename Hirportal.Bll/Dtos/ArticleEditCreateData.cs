using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleEditCreateData
    {     
        public string Title { get; set; }

        public string ThumbnailContent { get; set; }

        public string HtmlContent { get; set; }

        public string CoverImageUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ArchiveDate { get; set; }

        public ColumnData Column { get; set; }

        public List<TagData> Tags { get; set; }

        public string AuthorId { get; set; }
    }
}
