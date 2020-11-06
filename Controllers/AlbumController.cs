using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoApi.Interfaces;
using PhotoApi.Models;

namespace PhotoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private IAlbumRepository _repository;

        public AlbumController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}", Name = "GetAlbum")]
        public Album Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Album
        [Authorize]
        [HttpPost]
        public void Post([FromBody] Album album)
        {
            _repository.Create(album);
        }

        // PUT: api/Album/5
        [Authorize]
        [HttpPut]
        public void Put([FromBody] Album album)
        {
            _repository.Update(album);
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
