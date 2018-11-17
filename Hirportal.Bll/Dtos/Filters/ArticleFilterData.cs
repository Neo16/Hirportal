using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos
{
    public class ArticleFilterData
    {
        public int PageStart { get; set; }
        public int PageLength { get; set; }
        public string FreeTextParam { get; set; }
        public List<TagData> Tags { get; set; }        
    }
}
