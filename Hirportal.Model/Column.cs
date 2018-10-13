using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Model
{
    public class Column
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
