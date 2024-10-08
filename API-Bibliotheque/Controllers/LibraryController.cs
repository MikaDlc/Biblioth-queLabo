﻿using Commun_Bibliotheque.Repositories;
using BLL = BLL_Bibliotheque.Entities;
using Microsoft.AspNetCore.Mvc;
using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private ILibraryRepository<BLL.Library> _libraryRepository;
        public LibraryController(ILibraryRepository<BLL.Library> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_libraryRepository.Get().Select(l => l.ToAPI()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var library = _libraryRepository.Get(id);
                return Ok(library.ToAPIDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] LibraryPost library)
        {
            try
            {
                if (library == null)
                    return BadRequest();
                _libraryRepository.Insert(library.ToBLL());
                return CreatedAtAction(nameof(Get), library);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] LibraryPost library)
        {
            if (library == null)
                return BadRequest();
            _libraryRepository.Update(id, library.ToBLL());
            return NoContent();
        }

    }
}
