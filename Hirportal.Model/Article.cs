using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Model
{
    public class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string HtmlContent  { get; set; }

        public string  CoverImageUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ArchiveDate { get; set; }

        public Column Column { get; set; }
        public Guid ColumnId { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }
      
        public ApplicationUser Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
