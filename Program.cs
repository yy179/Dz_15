using Dz_15.Models;

namespace Dz_15
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BooksContext();
            var libraryService = new LibraryService(context);

            while (true)
            {
                Console.WriteLine("1. Додати книгу");
                Console.WriteLine("2. Додати автора");
                Console.WriteLine("3. Додати жанр");
                Console.WriteLine("4. Вивести список книг");
                Console.WriteLine("5. Вихід");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        var newBook = new BookEntity();
                        Console.Write("Введіть назву книги: ");
                        newBook.Title = Console.ReadLine();

                        Console.Write("Введіть ім'я автора: ");
                        var authorName = Console.ReadLine();
                        var author = libraryService.GetAuthorByName(authorName);
                        if (author == null)
                        {
                            author = new AuthorEntity { Name = authorName };
                            libraryService.AddAuthor(author);
                        }

                        newBook.Author = author; 

                        Console.Write("Введіть жанр: ");
                        var genreName = Console.ReadLine();
                        var genre = libraryService.GetGenreByName(genreName);
                        if (genre == null)
                        {

                            genre = new GenreEntity { Name = genreName };
                            libraryService.AddGenre(genre);
                        }

                        newBook.Genre = genre; 

                        Console.Write("Введіть рік видання: ");
                        newBook.PublishedYear = int.Parse(Console.ReadLine());
                        libraryService.AddBook(newBook);
                        Console.WriteLine("Книга додана!");
                        break;


                    case "2":

                        var newAuthor = new AuthorEntity();
                        Console.Write("Введіть ім'я автора: ");
                        newAuthor.Name = Console.ReadLine();
                        Console.Write("Введіть дату народження автора (yyyy-mm-dd): ");
                        newAuthor.DateOfBirth = DateTime.Parse(Console.ReadLine());
                        libraryService.AddAuthor(newAuthor);
                        Console.WriteLine("Автор доданий!");
                        break;

                    case "3":

                        var newGenre = new GenreEntity();
                        Console.Write("Введіть назву жанру: ");
                        newGenre.Name = Console.ReadLine();
                        libraryService.AddGenre(newGenre);
                        Console.WriteLine("Жанр доданий!");
                        break;

                    case "4":

                        var books = libraryService.GetAllBooks();
                        foreach (var book in books)
                        {
                            Console.WriteLine($"ID: {book.Id}, Назва: {book.Title}, Автор: {book.Author}, Жанр: {book.Genre}, Рік видання: {book.PublishedYear}");
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}