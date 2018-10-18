using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Model.MainPage
{
    /// <summary>
    /// Represents an article thumbnail cell on the main page 
    /// displayed in one of the mainpage blocks 
    /// </summary>
    public class MainPageCell
    {
        public Guid Id { get; set; }
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }

        public MainPageBlock MainPageBlock { get; set; }
        public Guid MainPageBlockId { get; set; }

        public int DisplayId { get; set; }
    }
}
