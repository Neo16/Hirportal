using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleAdminHeaderData
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ArchiveDate { get; set; }

        public ColumnData Column { get; set; }

        public AuthorData Author { get; set; }

        public List<TagData> Tags { get; set; }
    }
}
