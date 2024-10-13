using System.Collections.Generic;
using System.Linq;
using Dz_15.Models;
using Microsoft.EntityFrameworkCore;

namespace Dz_15
{
    public class LibraryService
    {
        private readonly BooksContext _context;

        public LibraryService(BooksContext context)
        {
            _context = context;
        }


        public void AddBook(BookEntity book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public BookEntity GetBookById(Guid id)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre).FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(BookEntity book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Guid id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<BookEntity> GetAllBooks()
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre).ToList();
        }


        public void AddAuthor(AuthorEntity author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public AuthorEntity GetAuthorByName(string name)
        {
            return _context.Authors.FirstOrDefault(a => a.Name == name);
        }

        public List<AuthorEntity> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public void DeleteAuthor(Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }


        public void AddGenre(GenreEntity genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public GenreEntity GetGenreByName(string name)
        {
            return _context.Genres.FirstOrDefault(g => g.Name == name);
        }

        public List<GenreEntity> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public void DeleteGenre(Guid id)
        {
            var genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}

