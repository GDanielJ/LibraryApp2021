using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BookToReturnDto
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorFirstname { get; set; }
        public string AuthorLastname { get; set; }
    }
}
