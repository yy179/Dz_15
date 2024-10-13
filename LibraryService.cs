using Dz_15.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddAuthor(AuthorEntity author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddGenre(GenreEntity genre)
        {
            
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public IEnumerable<BookEntity> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToList();
        }
        public AuthorEntity GetAuthorByName(string name)
        {
            return _context.Authors.FirstOrDefault(a => a.Name == name);
        }

        public GenreEntity GetGenreByName(string name)
        {
            return _context.Genres.FirstOrDefault(g => g.Name == name);
        }

    }

}
