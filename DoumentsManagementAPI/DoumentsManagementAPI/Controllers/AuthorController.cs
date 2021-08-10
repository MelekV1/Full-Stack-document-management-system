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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        [HttpGet("getAuthors")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            return Ok(authors);
        }
        [HttpGet("getAuthor/{id}")]
        public async Task<Author> GetAuthorById(int id)
        {
            return await _authorService.GetAuthorById(id);
        }
        [HttpPost()]
        public async Task<ActionResult<Author>> CreateUser([FromBody] Author author)
        {
            return await _authorService.CreateAuthor(author);
        }
    }
}
