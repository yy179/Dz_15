using Dz_15.Models;
using Dz_15.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_15
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksContext _context;
        private IRepository<BookEntity> _books;
        private IRepository<AuthorEntity> _authors;
        private IRepository<GenreEntity> _genres;

        public UnitOfWork(BooksContext context)
        {
            _context = context;
        }

        public IRepository<BookEntity> Books => _books ??= new Repository<BookEntity>(_context);
        public IRepository<AuthorEntity> Authors => _authors ??= new Repository<AuthorEntity>(_context);
        public IRepository<GenreEntity> Genres => _genres ??= new Repository<GenreEntity>(_context);

        public void Commit() => _context.SaveChanges();
    }
}
