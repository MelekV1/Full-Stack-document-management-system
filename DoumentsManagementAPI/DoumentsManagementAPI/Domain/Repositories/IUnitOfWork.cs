using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepo Authors { get; }
        IDocumentRepo Documents { get; }
        ICategoryRepo Categories { get; }
        IUserRepo Users { get; }
        Task<int> CommitAsync();
    }
}
