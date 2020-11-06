using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoApi.Interfaces;
using PhotoApi.Models;
using PhotoApi.Services;

namespace PhotoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private IPhotoRepository _repository;
        private IAuthorRepository _authorRepository;
        public PhotoController( IPhotoRepository repository, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _repository = repository;
        }

        // GET: api/Photo
        [HttpGet]
        public IEnumerable<Photo> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Photo/5
        [HttpGet("{id}", Name = "GetPhoto")]
        public Photo Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Photo
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] string name, [FromForm]string authorId, [FromForm]string dateOfMade, [FromForm]string cameraModel, [FromForm]IFormFile uploadedFile)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "id");
            var userId = Int32.Parse(userIdClaim.Value);
            var author = _authorRepository.FindByUserId(userId);
            if (author.Id == Int32.Parse(authorId))
            {
                var currentPhoto = new Photo { Name = name, AuthorId = Int32.Parse(authorId), DateOfMade = DateTime.Parse(dateOfMade), CameraModel = cameraModel };
                _repository.Create(currentPhoto, uploadedFile);
                return Ok();
            }
            else
                return BadRequest();
        }

        // PUT: api/Photo/5
        [Authorize]
        [HttpPut]
        public void Put([FromBody] Photo value)
        {
            _repository.Update(value);
        }

        // DELETE: api/Photo/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
