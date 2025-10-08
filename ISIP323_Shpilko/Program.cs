public static class Programm
{
    public static void Main()
    {
        AddTestData();

        Console.WriteLine("Меню для управления");

        while (true)
        {
            Console.WriteLine("0. Вывод всех книг");
            Console.WriteLine("1. Добавление книги");
            Console.WriteLine("2. Удаление книги по ID");
            Console.WriteLine("3. Поиск книги по названию");
            Console.WriteLine("4. Поиск книги по автору");
            Console.WriteLine("5. Поиск книги по жанру");
            Console.WriteLine("6. Сортировка по названию");
            Console.WriteLine("7. Сортировка по году");
            Console.WriteLine("8. Вывод самой дешевой книги");
            Console.WriteLine("9. Вывод самой дорогой книги");
            Console.WriteLine("10. Вывод количества книг каждого автора");
            Console.WriteLine("11. Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    OuptputAllBooks();
                    break;
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    SearchNameBook();
                    break;
                case "4":
                    SearchAutorBook();
                    break;
                case "5":
                    SearchJanreBook();
                    break;
                case "6":
                    SortByName();
                    break;
                case "7":
                    SortByYear();
                    break;
                case "8":
                    OutputMinPrice();
                    break;
                case "9":
                    OutputMaxPrice();
                    break;
                case "10":
                    OutputCountBookAutor();
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
    static List<Book> books = new List<Book>();
    static void OuptputAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("библиотека пуста");
            return;
        }

        Console.WriteLine("\nсписок всех книг в библиотеке:\n");
        foreach (var book in books)
        {
            Console.WriteLine(book.Print());
        }
        Console.WriteLine();
    }
    static void AddTestData()
    {
        books.Add(new Book("гуччи пудж", 1500m, 1966, "Лобочкин Максим", BookJanre.Fantasy));
        books.Add(new Book("убийство виспа(ио)", 1200m, 1866, "Гусенков Вадим", BookJanre.Drama));
        books.Add(new Book("1994 урса на лайне", 2000m, 1867, "Шпилько Максим", BookJanre.Drama));
        books.Add(new Book("гордость за команду", 800m, 1833, "Пермякова Мария", BookJanre.Romantic));
        books.Add(new Book("расследование на складе озон", 1800m, 1997, "Зевакин Даниил", BookJanre.Fantasy));

        Console.WriteLine("тестовые данные добавлены успешно");
        Console.WriteLine($"добавлено 5 тестовых книг");
    }

    static void AddBook()
    {
        Console.Write("введите название книги: ");
        string name = Console.ReadLine();

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
        foreach (BookJanre genre in Enum.GetValues(typeof(BookJanre)))
        {
            Console.WriteLine($"{index}. {genre}");
            index++;
        }

        int genreChoice;
        while (!int.TryParse(Console.ReadLine(), out genreChoice) || genreChoice < 1 || genreChoice > Enum.GetValues(typeof(BookJanre)).Length)
        {
            Console.Write("некорректный выбор");
        }

        BookJanre selectedGenre = (BookJanre)Enum.GetValues(typeof(BookJanre)).GetValue(genreChoice - 1);

        Book newBook = new Book(name, price, year, author, selectedGenre);
        books.Add(newBook);



    }
}

public enum BookJanre
{
    Romantic,
    Fantasy,
    Drama
}
public class Book
{
    private static int nextID = 1;
    public int ID { get; }
    public string Name { get; private set; }
    public string Autor { get; private set; }
    public BookJanre Janre { get; private set; }
    public int Year { get; private set; }
    public decimal Price { get; private set; }

    public Book(string name, decimal price, int year, string autor, BookJanre category)
    {
        if (name == null) throw new ArgumentNullException("укажите название книги");
        if (autor == null) throw new ArgumentNullException("укажите автора");
        if (year <= 0) throw new ArgumentOutOfRangeException("год не может быть отрицательным");
        if (price <= 0) throw new ArgumentOutOfRangeException("цена должна быть положительной");

        ID = nextID++;
        Name = name;
        Price = price;
        Year = year;
        Autor = autor;
        Janre = category;
    }

    public string Print()
    {
        return $"код: {ID}, название: {Name}, цена: {Price:R}, год выхода: {Year}, автор: {Autor}, жанр: {Janre}";
    }

}