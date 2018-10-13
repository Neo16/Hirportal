using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Model
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
