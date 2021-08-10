using DoumentsManagementAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocumentById(int id);
        Task DeleteDocument(Document documentToDelete);
        Task<Document> createDocument(Document newDocument);
    }
}
