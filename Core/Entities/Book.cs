using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Book : BaseEntitiy
    {
        public int ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
    }
}
