using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoumentsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }
        // GET: api/document/getAllDocuments
        [HttpGet("getAllDocuments")]
        public async Task<ActionResult<IEnumerable<Document>>> GetAllCategories()
        {
            var documents = await _documentService.GetAllDocuments();
            return Ok(documents);
        }
        // GET: api/document/getDocument/1
        [HttpGet("getDocument/{id}")]
        public async Task<Document> GetDocumentById(int id)
        {
            return await _documentService.GetDocumentById(id);
        }

        // Post: api/document
        [HttpPost()]
        public async Task<ActionResult<Document>> CreateUser([FromBody]Document document)
        {
            return await _documentService.createDocument(document);
        }
    }
}
