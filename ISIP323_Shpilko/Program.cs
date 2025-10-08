public static class Programm
{
    public static void Main()
    {
        AddTestBooks();

        Console.WriteLine("меню библиотеки");

        while (true)
        {
            Console.WriteLine("0. добавить книги");
            Console.WriteLine("1. вывод книг");
            Console.WriteLine("2. удаление книг по Id");
            Console.WriteLine("3. поиск книг (название)");
            Console.WriteLine("4. сортировка книг (название)");
            Console.WriteLine("5. поиск книг (жанр)");
            Console.WriteLine("6. поиск книг (автор)");
            Console.WriteLine("7. сортировка книг (год)");
            Console.WriteLine("8. показать самую дорогую книгу");
            Console.WriteLine("9. показать самую дешевую книгу");
            Console.WriteLine("10. вывод количества книг каждого автора");
            Console.WriteLine("11. выход из приложения");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    AddBooks();
                    break;
                case "1":
                    AllBooks();
                    break;
                case "2":
                    RemoveBooks();
                    break;
                case "3":
                    SearchTitleBook();
                    break;
                case "4":
                    TitleSort();
                    break;
                case "5":
                    SearchGenreBooks();
                    break;
                case "6":
                    SearchAuthorBooks();
                    break;
                case "7":
                    YearSort();
                    break;
                case "8":
                    MaxPrice();
                    break;
                case "9":
                    LowPrice();
                    break;
                case "10":
                    AuthorBooksCount();
                    break;
                case "11":
                    Console.WriteLine("возвращайтесь еще");
                    return;
                default:
                    Console.WriteLine("не то");
                    break;
            }
        }
    }
    public enum GenreBook
    {
        Romantic,
        Fantasy,
        Drama,
        Biography,
        Mystery
    }
    public class Book
    {
        private static int nextID = 1;
        public int ID { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public GenreBook Genre { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Book(string title, decimal price, int year, string author, GenreBook category)
        {
            if (title == null) throw new ArgumentNullException("укажите название книги");
            if (author == null) throw new ArgumentNullException("укажите автора");
            if (year <= 0) throw new ArgumentOutOfRangeException("год не может быть отрицательным");
            if (price <= 0) throw new ArgumentOutOfRangeException("цена должна быть положительной");

            ID = nextID++;
            Title = title;
            Price = price;
            Year = year;
            Author = author;
            Genre = category;
        }
        public string Print()
        {
            return $"Id: {ID}, title: {Title}, price: {Price:R}, year: {Year}, author: {Author}, genre: {Genre}";
        }
    }
    static List<Book> books = new List<Book>();
    static void AllBooks()
    {
        Console.WriteLine("\nсписок всех книг в библиотеке:\n");
        foreach (var book in books)
        {
            Console.WriteLine(book.Print());
        }
        Console.WriteLine();

        if (books.Count == 0)
        {
            Console.WriteLine("библиотека пуста");
            return;
        }
    }
    static void AddTestBooks()
    {
        books.Add(new Book("гуччи пудж", 1500m, 1966, "Лобочкин Максим", GenreBook.Fantasy));
        books.Add(new Book("убийство виспа(ио)", 1200m, 1866, "Гусенков Вадим", GenreBook.Drama));
        books.Add(new Book("1994 урса на лайне", 2000m, 1867, "Шпилько Максим", GenreBook.Drama));
        books.Add(new Book("гордость за команду", 800m, 1833, "Пермякова Мария", GenreBook.Romantic));
        books.Add(new Book("расследование на складе озон", 1800m, 1997, "Зевакин Даниил", GenreBook.Fantasy));

        Console.WriteLine("тестовые данные добавлены успешно");
        Console.WriteLine($"добавлено 5 тестовых книг");
    }

    static void AddBooks()
    {
        Console.Write("введите название книги: ");
        string title = Console.ReadLine();

        Console.Write("введите автора: ");
        string author = Console.ReadLine();

        Console.Write("введите год издания: ");
        int year;
        while (!int.TryParse(Console.ReadLine(), out year) || year <= 0)
        {
            Console.Write("некорректный ввод. Введите год издания снова: ");
        }

        Console.Write("введите цену: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
        {
            Console.Write("некорректный ввод. Введите положительную цену: ");
        }

        Console.WriteLine("\nвыберите жанр:");
        int index = 1;
        foreach (GenreBook genre in Enum.GetValues(typeof(GenreBook)))
        {
            Console.WriteLine($"{index}. {genre}");
            index++;
        }

        int genreChoice;
        while (!int.TryParse(Console.ReadLine(), out genreChoice) || genreChoice < 1 || genreChoice > Enum.GetValues(typeof(GenreBook)).Length)
        {
            Console.Write("некорректный выбор");
        }

        GenreBook selectedGenre = (GenreBook)Enum.GetValues(typeof(GenreBook)).GetValue(genreChoice - 1);

        Book newBook = new Book(title, price, year, author, selectedGenre);
        books.Add(newBook);
    }

    static void RemoveBooks()
    {
        Console.Write("введите ID для удаления:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id))
        {
            var book = books.FirstOrDefault(b => b.ID == id);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("успешно");
            }
        }
    }

    static void SearchTitleBook()
    {
        Console.Write("введите название книги: ");
        string title = Console.ReadLine().ToLower();
        var results = books.Where(b => b.Title.ToLower().Contains(title)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("книги не найдены");
        }
        else
        {
            results.ForEach(b => Console.WriteLine(b.Print()));
        }
    }


    static void SearchAuthorBooks()
    {
        Console.Write("введите автора книги:");
        string Author = Console.ReadLine().ToLower();
        var results = books.Where(b => b.Author.ToLower().Contains(Author)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("книги не найдены");
        }
        else
        {
            results.ForEach(b => Console.WriteLine(b.Print()));
        }
    }

    static void SearchGenreBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("библиотека пуста\n");
            return;
        }

        Console.WriteLine("выберите жанр:");
        foreach (var genre in Enum.GetValues(typeof(GenreBook)))
            Console.WriteLine($"{(int)genre} — {genre}");

        Console.Write("\nвведите номер жанра:");
        if (!int.TryParse(Console.ReadLine(), out int choice) || !Enum.IsDefined(typeof(GenreBook), choice))
        {
            Console.WriteLine("некорректный выбор\n");
            return;
        }

        GenreBook selectedGenre = (GenreBook)choice;

        var filteredBooks = books.Where(b => b.Genre == selectedGenre).ToList();

        if (filteredBooks.Count == 0)
        {
            Console.WriteLine($"книг жанра {selectedGenre} не найдено\n");
            return;
        }

        Console.WriteLine($"\nкниги жанра {selectedGenre}:\n");
        foreach (var book in filteredBooks)
            Console.WriteLine(book.Print());

    }

    static void TitleSort()
    {
        var sorted = books.OrderBy(b => b.Title).ToList();
        sorted.ForEach(b => Console.WriteLine(b.Print()));
    }

    static void YearSort()
    {
        var sorted = books.OrderBy(b => b.Year).ToList();
        sorted.ForEach(b => Console.WriteLine(b.Print()));
    }

    static void LowPrice()
    {
        var min = books.OrderBy(b => b.Price).ToList().FirstOrDefault();
        Console.WriteLine(min.Print());
    }

    static void MaxPrice()
    {
        var max = books.OrderBy(b => b.Price).ToList().LastOrDefault();
        Console.WriteLine(max.Print());
    }

    static void AuthorBooksCount()
    {
        var groups = books.GroupBy(b => b.Author)
                           .Select(g => new { Author = g.Key, Count = g.Count() });
        Console.WriteLine("количество книг по авторам:");
        foreach (var g in groups)
        {
            Console.WriteLine($"{g.Author}: {g.Count}");
        }
        Console.WriteLine();
    }
}


