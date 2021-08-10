using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Document> createDocument(Document newDocument)
        {
            await _unitOfWork.Documents.AddAsync(newDocument);
            await _unitOfWork.CommitAsync();
            return newDocument;
        }

        public Task DeleteDocument(Document documentToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            return await _unitOfWork.Documents.GetAllAsync();
        }

        public async Task<Document> GetDocumentById(int id)
        {
            return await _unitOfWork.Documents.GetByIdAsync(id);
        }
    }
}
