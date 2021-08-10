using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Models
{
    public class Document
    {
        public int DocId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }

        public Author DocumentAuthor { get; set; }
        public int CategoryId { get; set; }

        public Category Type { get; set; }
    }
}
