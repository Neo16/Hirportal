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
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<MainPageCell> MainPageCells { get; set; }
    }
}
