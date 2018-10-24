using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Model.MainPage
{
    /// <summary>
    /// represents a block (of article thumbnails) on the mainpage 
    /// </summary>
    public class MainPageBlock
    {
        public bool IsLeadBlock { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<MainPageCell> MainPageCells { get; set; }
    }
}
