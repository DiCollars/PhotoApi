using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoApi.Interfaces;
using PhotoApi.Models;

namespace PhotoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public Author Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Author
        [Authorize]
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _repository.Create(author);
        }

        // PUT: api/Author/5
        [Authorize]
        [HttpPut]
        public void Put([FromBody] Author author)
        {
            _repository.Update(author);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
