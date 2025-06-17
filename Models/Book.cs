using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.API.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ResponseDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Author> Authors { get; set; }
        public List<Tags> Tags { get; set; }

    }
}