using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
