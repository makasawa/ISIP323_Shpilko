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
}