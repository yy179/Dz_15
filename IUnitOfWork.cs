using Dz_15.Models;
using Dz_15.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_15
{
    public interface IUnitOfWork
    {
        IRepository<BookEntity> Books { get; }
        IRepository<AuthorEntity> Authors { get; }
        IRepository<GenreEntity> Genres { get; }
        void Commit();
    }

}
