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
