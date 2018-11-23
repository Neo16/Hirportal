using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Dtos.MainPage
{
    public class MainPageBlockData
    {
        public string Name { get; set; }

        public List<MainPageCellData> Cells { get; set; }

        public bool IsLeadBlock { get; set; }

        public Guid Id { get; set; }
    }
}
