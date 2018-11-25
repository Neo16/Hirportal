using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleEditCreateData
    {     
        [Required]
        public string Title { get; set; }

        public string ThumbnailContent { get; set; }

        [Required]
        public string HtmlContent { get; set; }

        public string CoverImageUrl { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public DateTime ArchiveDate { get; set; }

        [Required]
        public ColumnData Column { get; set; }

        public List<TagData> Tags { get; set; }

        public string AuthorId { get; set; }
    }
}
