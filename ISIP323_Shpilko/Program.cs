using System.Collections.Generic;

namespace Magaz
{
    public enum ProductCategorii
    {
        Eda,
        Electronika,
        Odejda
    }

    public class Product
    {
        public string Name { get; set; }
        public string Code { get; }
        public decimal Price { get; set; }
        public int Colichestvo { get; set; }
        public bool Nalichie => Colichestvo > 0;
        public ProductCategorii Categorii { get; set; }

        public Product(string name, string code, decimal price, int colich, ProductCategorii categorii)
        {
            Name = name;
            Code = code;
            Price = price;
            Colichestvo = colich;
            Categorii = categorii;
        }

        public override string ToString()
        {
            return $"Код: {Code}, Название: {Name}, Цена: {Price:C}, " +
            $"Количество: {Colichestvo}, В наличии: {(Nalichie ? "Да" : "Нет")}, " +
            $"Категория: {Categorii}";
        }
    }

    public class MagazManager
    {
        private List products;
        private int nextProductId;

        public MagazManager()
        {
            products = new List();
            nextProductId = 1;
            MagazData();
        }

        private void MagazData()
        {
            AddProduct("Notebook Apple", 45000m, 5, ProductCategorii.Electronika);
            AddProduct("T-shirt Sigma", 1500m, 20, ProductCategorii.Odejda);
            AddProduct("Hleb", 500m, 40, ProductCategorii.Eda);
            AddProduct("Yabloko", 500m, 100, ProductCategorii.Eda);
            AddProduct("Jeans Levis", 2000m, 15, ProductCategorii.Odejda);
        }

        private string ProductCodeGenerate()
        {
            return $"1{nextProductId++}";
        }

        public void AddProduct(string name, decimal price, int colich, ProductCategorii categorii)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ошибка, название товара не может быть пустым");
                return;
            }
            if (price < 0)
            {
                Console.WriteLine("Ошибка, товар должен иметь цену");
                return;
            }
            if (colich < 0)
            {
                Console.WriteLine("Ошибка, товара нет на складе");
                return;
            }

            string code = ProductCodeGenerate();
            Product product = new Product(name, code, price, colich, categorii);
            products.Add(product);
            Console.WriteLine($"Товар добавлен, код товара: {code}");
        }
        public void RemoveProduct(string code)
        {
            foreach (Product p in products)
            {
                if (p.Code == code)
                {
                    products.Remove(p);
                    Console.WriteLine($"Товар с кодом {code} успешно удалён");
                }
                else
                {
                    Console.WriteLine($"Товар с кодом {code} не найден");
                }
            }
            foreach (Product p in products)
            {
                if (p.Code == code)
                {
                    products.Remove(p);
                    Console.WriteLine($"Товар с кодом {code} успешно удалён");
                }
                else
                {
                    Console.WriteLine($"Товар с кодом {code} не найден");
                }
            }
        }
        public void OrderSupply(string code, int colich)
        {
            if (colich <= 0)
            {
                Console.WriteLine("Ошибка: Количество должно быть положительным");
                return;
            }

            foreach (Product p in products)
            {
                if (p != null)
                {
                    p.Colichestvo += colich;
                    Console.WriteLine($"Поставка успешно оформлена, новое кол-вор: {p.Colichestvo}");
                }
                else
                {
                    Console.WriteLine($"Товар с кодом {code} не найден");
                }
            }
        }
        public void SellProduct(string code, int colich)
        {
            if (colich <= 0)
            {
                Console.WriteLine("Ошибка: Количество должно быть положительным!");
                return;
            }

            foreach (Product p in products)
            {
                if (p != null)
                {
                    if (p.Colichestvo >= colich)
                    {
                        p.Colichestvo -= colich;
                        decimal totalPrice = p.Price * colich;
                        Console.WriteLine($"Продажа успешна " +
                        $"Продано: {colich} шт., Общая сумма: {totalPrice:C}, " +
                        $"Остаток: {p.Colichestvo} шт.");
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Недостаточно товара на складе " +
                        $"Доступно: {p.Colichestvo}, Заказано: {colich}");
                    }
                }
                else
                {
                    Console.WriteLine($"Товар с кодом {code} не найден");
                }
            }
        }
        public void SearchByCode(string code)
        {
            foreach (Product p in products)
            {
                if (p != null)
                {
                    Console.WriteLine("Найден товар:");
                    Console.WriteLine(p);
                }
                else
                {
                    Console.WriteLine($"Товар с кодом {code} не найден");
                }
            }
        }

        public void SearchByName(string name)
        {
            var foundProducts = products
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

            if (foundProducts.Any())
            {
                Console.WriteLine($"Найдено товаров: {foundProducts.Count}");
                foreach (var product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine($"Товары с названием '{name}' не найдены");
            }
        }
