using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_15
{
    public class BookContextFactory : IDesignTimeDbContextFactory<BooksContext>
    {
        public BooksContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\Dz_15DB.mdf;Integrated Security=True;Connect Timeout=30");

            return new BooksContext(optionsBuilder.Options);
        }
    }
}
