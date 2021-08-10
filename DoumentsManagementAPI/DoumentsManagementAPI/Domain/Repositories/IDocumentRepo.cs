using DoumentsManagementAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Repositories
{
    public interface IDocumentRepo : IRepository<Document>
    {
        //Task<IEnumerable<Document>> GetAllWithAuthorsAsync();
        //Task<Document> GetWithAuthorByIdAsync(int id);
        //Task<IEnumerable<Document>> GetAllWithAuthorByAuthorIdAsync(int authorId);
    }
}
