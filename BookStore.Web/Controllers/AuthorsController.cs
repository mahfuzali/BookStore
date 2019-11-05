using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Web.Models;
using BookStore.Web.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStore.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IBookStoreRepository bookStoreRepository, IMapper mapper)
        {
            _bookStoreRepository = bookStoreRepository ??
                throw new ArgumentNullException(nameof(bookStoreRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            var authorsFromRepo = _bookStoreRepository.GetAuthors(authorsResourceParameters);
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _bookStoreRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _bookStoreRepository.AddAuthor(authorEntity);
            _bookStoreRepository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("GetAuthor", 
                    new { authorId = authorToReturn.Id}, 
                    authorToReturn);
        }
    }
}