using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Author> CreateAuthor(Author newAuthor)
        {
            await _unitOfWork.Authors.AddAsync(newAuthor);
            await _unitOfWork.CommitAsync();
            return newAuthor;
        }
        public async Task<Author> GetAuthorById(int id)
        {
            return await _unitOfWork.Authors.GetByIdAsync(id);
        }

        public async Task DeleteAuthor(Author authorToDelete)
        {
            _unitOfWork.Authors.Remove(authorToDelete);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _unitOfWork.Authors.GetAllAsync();
        }
    }
}
