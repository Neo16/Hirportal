using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos.MainPage
{
    public class MainPageData
    {
        public List<MainPageBlockData> Blocks { get; set; }

        //Todo map (db-be isMain bool)
        public MainPageBlockData MainBlock { get; set; }

        //Todo map 
        public ArticleHeaderData LeadArticle  { get; set; }
    }
}
