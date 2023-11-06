﻿using EntityFrameworkLab3Api.Models;

namespace EntityFrameworkLab3Api.Services;

public interface ILibraryService
{
    // Author Services
    Task<List<Author>> GetAuthorsAsync(); // GET All Authors
    Task<Author> GetAuthorAsync(Guid id, bool includeBooks = false); // GET Single Author
    Task<Author> AddAuthorAsync(Author author); // POST New Author
    Task<Author> UpdateAuthorAsync(Author author); // PUT Author
    Task<(bool, string)> DeleteAuthorAsync(Author author); // DELETE Author

    // Book Services
    Task<List<Book>> GetBooksAsync(); // GET All Books
    Task<Book> GetBookAsync(Guid id); // Get Single Book
    Task<Book> AddBookAsync(Book book); // POST New Book
    Task<Book> UpdateBookAsync(Book book); // PUT Book
    Task<(bool, string)> DeleteBookAsync(Book book); // DELETE Book
}