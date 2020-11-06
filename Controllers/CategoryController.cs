using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoApi.Interfaces;
using PhotoApi.Models;

namespace PhotoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Category
        [Authorize]
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            _repository.Create(value);
        }

        // PUT: api/Category
        [Authorize]
        [HttpPut]
        public void Put([FromBody] Category value)
        {
            _repository.Update(value);
        }

        // DELETE: api/Category/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
