using Hirportal.Model.MainPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos.MainPage
{
    public class MainPageCellData
    {
        public ArticleHeaderData Article { get; set; }

        public int DisplayIndex { get; set; }

        public CellSize CellSize { get; set; }
    }
}
