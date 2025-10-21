using System;
using System.Threading;

namespace TextRoguelike
{
    class Program
    {
        static Random rng = new Random();

        static void Main()
        {
            

        }

        static void Battle(Player player, Enemy enemy)
        {
            
            }


        

        static void Chest(Player player)
        {
            
            }
        }
    }


    class Player
    {
        public int MaxHP { get; private set; } = 100;
        public int HP { get; set; } = 100;
        public int Attack => 10;
        public bool DefendNext { get; set; } = false;
        public Item Weapon { get; set; } = new Item("Дипсиковая палка", attack: 2);
        public Item Armor { get; set; } = new Item("Гптшные доспехи", defense: 1);
    }

    class Item
    {
        public string Name { get; }
        public int Attack { get; }
        public int Defense { get; }

        public Item(string name, int attack = 0, int defense = 0)
        {
        }

        public override string ToString()
        {
          
        }
    }

    class Enemy
    {
        static Random rng = new Random();

        public string Name { get; set; }
        public int HP { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public string Type { get; set; }
        public double CritChance { get; set; } = 0;
        public double FreezeChance { get; set; } = 0;
        public bool IgnoreDefense { get; set; } = false;

    public bool AttackPlayer(Player player, out bool froze)
    {
        froze = false;
        int damage = AttackPower;
        bool crit = rng.NextDouble() < CritChance;
        if (crit)
        {
            damage = (int)(damage * 1.5);
            Console.WriteLine("Критическое думанье!");
        }

        if (!IgnoreDefense)
        {
            int defense = player.Armor.Defense;
            if (player.DefendNext)
            {
                if (rng.NextDouble() < 0.4)
                {
                    Console.WriteLine("Вы скрыли тягу!");
                    player.DefendNext = false;
                    return false;
                }
                int blockPercent = rng.Next(70, 101);
                int reduced = defense * blockPercent / 100;
                damage = Math.Max(0, damage - reduced);
                player.DefendNext = false;
                Console.WriteLine($"Вы блокировали {blockPercent}% урона.");
            }
            else
            {
                damage = Math.Max(0, damage - defense);
            }
        }

        Console.WriteLine($"{Name} думает и надумывает на {damage} урона!");
        player.HP -= damage;

        if (FreezeChance > 0 && rng.NextDouble() < FreezeChance)
        {
            Console.WriteLine($"{Name} накладывает заморозку!");
            froze = true;
        }

        return true;
    }

    public static Enemy GenerateEnemy()
    {
        string[] types = { "Гоблин", "Скелет", "Маг" };
        string t = types[rng.Next(types.Length)];

        return t switch
        {
            "Гоблин" => new Enemy { Name = "Гоблин", Type = "Гоблин", HP = 30, AttackPower = 8, Defense = 3, CritChance = 0.2 },
            "Скелет" => new Enemy { Name = "Скелет", Type = "Скелет", HP = 35, AttackPower = 9, Defense = 4, IgnoreDefense = true },
            "Маг" => new Enemy { Name = "Маг", Type = "Маг", HP = 25, AttackPower = 7, Defense = 2, FreezeChance = 0.25 },
            _ => throw new Exception("Неизвестный тип врага"),
        };
    }

    public static Enemy GenerateBoss()
    {
        string[] bosses = { "ВВГ", "Ковальский", "C++", "Python" };
        string name = bosses[rng.Next(bosses.Length)];

        return name switch
        {
            "ВВГ" => new Enemy
            {
                Name = "ВВГ (Гоблин-босс)",
                Type = "Гоблин",
                HP = (int)(30 * 2.0),
                AttackPower = (int)(8 * 1.5),
                Defense = (int)(3 * 1.2),
                CritChance = 0.2 + 0.1
            },
            "Ковальский" => new Enemy { Name = "Ковальский (Скелет-босс)", Type = "Скелет", HP = (int)(35 * 2.5), AttackPower = (int)(9 * 1.3), Defense = (int)(4 * 1.4), IgnoreDefense = true },
            "Архимаг C++" => new Enemy { Name = "C++ (Маг-босс)", Type = "Маг", HP = (int)(25 * 1.8), AttackPower = (int)(7 * 1.6), Defense = (int)(2 * 1.1), FreezeChance = 0.25 + 0.1 },
            "Пестов С--" => new Enemy { Name = "Python (Скелет)", Type = "Скелет", HP = (int)(35 * 1.3), AttackPower = (int)(9 * 1.8), Defense = (int)(4 * 0.6), IgnoreDefense = true, FreezeChance = 0.25 + 0.15 },
            _ => throw new Exception("Неизвестный босс"),
        };
    }
}
}

