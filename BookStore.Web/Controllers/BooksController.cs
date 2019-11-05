using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStore.Web.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookStoreRepository bookStoreRepository,
            IMapper mapper)
        {
            _bookStoreRepository = bookStoreRepository ??
                throw new ArgumentNullException(nameof(bookStoreRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooksForAuthor(Guid authorId)
        {
            if (!_bookStoreRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var booksForAuthorFromRepo = _bookStoreRepository.GetBooks(authorId);
            return Ok(_mapper.Map<IEnumerable<BookDto>>(booksForAuthorFromRepo));
        }

        [HttpGet("{bookId}", Name = "GetBookForAuthor")]
        public ActionResult<BookDto> GetBookForAuthor(Guid authorId, Guid bookId)
        {
            if(!_bookStoreRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookForAuthorFromRepo = _bookStoreRepository.GetBook(authorId, bookId);

            if(bookForAuthorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(bookForAuthorFromRepo));
        }


        [HttpPost]
        public ActionResult<BookDto> CreateBookForAuthor(
            Guid authorId, BookForCreationDto book)
        {
            if (!_bookStoreRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookEntity = _mapper.Map<Book>(book);
            _bookStoreRepository.AddBook(authorId, bookEntity);
            _bookStoreRepository.Save();

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);
            return CreatedAtRoute("GetBookForAuthor",
                new { authorId = authorId, bookId = bookToReturn.Id} ,
                bookToReturn);
        }
    }
}