using DoumentsManagementAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task DeleteAuthor(Author authorToDelete);
        Task<Author> CreateAuthor(Author newAuthor);
    }
}
