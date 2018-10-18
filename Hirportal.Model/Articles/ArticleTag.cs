using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Model
{
    public class ArticleTag
    {
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
