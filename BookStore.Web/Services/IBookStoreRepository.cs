using BookStore.Core.Entities;
using BookStore.Web.ResourceParameters;
using System;
using System.Collections.Generic;

namespace BookStore.Web.Controllers
{
    public interface IBookStoreRepository
    {
        IEnumerable<Book> GetBooks(Guid authorId);

        Book GetBook(Guid authorId, Guid bookId);

        void AddBook(Guid authorId, Book book);

        void UpdateBook(Book book);

        void DeleteBook(Book book);

        IEnumerable<Author> GetAuthors();

        Author GetAuthor(Guid authorId);

        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        
        IEnumerable<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);

        void AddAuthor(Author author);

        void DeleteAuthor(Author author);

        void UpdateAuthor(Author author);

        bool AuthorExists(Guid authorId);

        bool Save();
    }
}