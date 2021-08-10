using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DocManagementAPIDBContext _context;

        private AuthorRepo _authorRepository;
        private DocumentRepo _documentRepository;
        private CategoryRepo _categoryRepository;
        private UserRepo _userRepository;

        public UnitOfWork(DocManagementAPIDBContext context)
        {
            this._context = context;
        }

        public IAuthorRepo Authors => _authorRepository = _authorRepository?? new AuthorRepo(_context);

        public IDocumentRepo Documents => _documentRepository = _documentRepository ?? new DocumentRepo(_context);

        public ICategoryRepo Categories => _categoryRepository = _categoryRepository ?? new CategoryRepo(_context);

        public IUserRepo Users => _userRepository = _userRepository ?? new UserRepo(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
