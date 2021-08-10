using DoumentsManagementAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Repositories
{
    public interface IAuthorRepo : IRepository<Author>
    {
        //Task<IEnumerable<Author>> GetAllWithDocumentsAsync();
        //Task<Author> GetWithDocumentsByIdAsync(int id);
    }
}
