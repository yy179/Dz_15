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
                Console.WriteLine("5. Оновити книгу");
                Console.WriteLine("6. Видалити книгу");
                Console.WriteLine("7. Вивести список авторів");
                Console.WriteLine("8. Видалити автора");
                Console.WriteLine("9. Вивести список жанрів");
                Console.WriteLine("10. Видалити жанр");
                Console.WriteLine("11. Вихід");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook(libraryService);
                        break;

                    case "2":
                        AddAuthor(libraryService);
                        break;

                    case "3":
                        AddGenre(libraryService);
                        break;

                    case "4":
                        DisplayBooks(libraryService);
                        break;

                    case "5":
                        UpdateBook(libraryService);
                        break;

                    case "6":
                        DeleteBook(libraryService);
                        break;

                    case "7":
                        DisplayAuthors(libraryService);
                        break;

                    case "8":
                        DeleteAuthor(libraryService);
                        break;

                    case "9":
                        DisplayGenres(libraryService);
                        break;

                    case "10":
                        DeleteGenre(libraryService);
                        break;

                    case "11":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        private static void AddBook(LibraryService libraryService)
        {
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
        }

        private static void AddAuthor(LibraryService libraryService)
        {
            var newAuthor = new AuthorEntity();
            Console.Write("Введіть ім'я автора: ");
            newAuthor.Name = Console.ReadLine();
            Console.Write("Введіть дату народження автора (yyyy-mm-dd): ");
            newAuthor.DateOfBirth = DateTime.Parse(Console.ReadLine());
            libraryService.AddAuthor(newAuthor);
            Console.WriteLine("Автор доданий!");
        }

        private static void AddGenre(LibraryService libraryService)
        {
            var newGenre = new GenreEntity();
            Console.Write("Введіть назву жанру: ");
            newGenre.Name = Console.ReadLine();
            libraryService.AddGenre(newGenre);
            Console.WriteLine("Жанр доданий!");
        }

        private static void DisplayBooks(LibraryService libraryService)
        {
            var books = libraryService.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Назва: {book.Title}, Автор: {book.Author.Name}, Жанр: {book.Genre.Name}, Рік видання: {book.PublishedYear}");
            }
        }

        private static void UpdateBook(LibraryService libraryService)
        {
            Console.Write("Введіть ID книги для оновлення: ");
            if (Guid.TryParse(Console.ReadLine(), out var bookId))
            {
                var book = libraryService.GetBookById(bookId);
                if (book == null)
                {
                    Console.WriteLine("Книга не знайдена.");
                    return;
                }

                Console.Write("Введіть нову назву книги: ");
                book.Title = Console.ReadLine();

                Console.Write("Введіть нове ім'я автора: ");
                var authorName = Console.ReadLine();
                var author = libraryService.GetAuthorByName(authorName);
                if (author == null)
                {
                    author = new AuthorEntity { Name = authorName };
                    libraryService.AddAuthor(author);
                }
                book.Author = author;

                Console.Write("Введіть новий жанр: ");
                var genreName = Console.ReadLine();
                var genre = libraryService.GetGenreByName(genreName);
                if (genre == null)
                {
                    genre = new GenreEntity { Name = genreName };
                    libraryService.AddGenre(genre);
                }
                book.Genre = genre;

                Console.Write("Введіть новий рік видання: ");
                book.PublishedYear = int.Parse(Console.ReadLine());
                libraryService.UpdateBook(book);
                Console.WriteLine("Книга оновлена!");
            }
            else
            {
                Console.WriteLine("Невірний формат ID.");
            }
        }

        private static void DeleteBook(LibraryService libraryService)
        {
            Console.Write("Введіть ID книги для видалення: ");
            if (Guid.TryParse(Console.ReadLine(), out var bookId))
            {
                libraryService.DeleteBook(bookId);
                Console.WriteLine("Книга видалена!");
            }
            else
            {
                Console.WriteLine("Невірний формат ID.");
            }
        }

        private static void DisplayAuthors(LibraryService libraryService)
        {
            var authors = libraryService.GetAllAuthors();
            foreach (var author in authors)
            {
                Console.WriteLine($"ID: {author.Id}, Ім'я: {author.Name}, Дата народження: {author.DateOfBirth}");
            }
        }

        private static void DeleteAuthor(LibraryService libraryService)
        {
            Console.Write("Введіть ID автора для видалення: ");
            if (Guid.TryParse(Console.ReadLine(), out var authorId))
            {
                libraryService.DeleteAuthor(authorId);
                Console.WriteLine("Автор видалений!");
            }
            else
            {
                Console.WriteLine("Невірний формат ID.");
            }
        }

        private static void DisplayGenres(LibraryService libraryService)
        {
            var genres = libraryService.GetAllGenres();
            foreach (var genre in genres)
            {
                Console.WriteLine($"ID: {genre.Id}, Назва: {genre.Name}");
            }
        }

        private static void DeleteGenre(LibraryService libraryService)
        {
            Console.Write("Введіть ID жанру для видалення: ");
            if (Guid.TryParse(Console.ReadLine(), out var genreId))
            {
                libraryService.DeleteGenre(genreId);
                Console.WriteLine("Жанр видалений!");
            }
            else
            {
                Console.WriteLine("Невірний формат ID.");
            }
        }
    }
}
