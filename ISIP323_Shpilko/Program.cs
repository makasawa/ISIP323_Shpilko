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
           
            }

            

        public static Enemy GenerateEnemy()
        {
           
        }

        public static Enemy GenerateBoss()
        {
           
         
        }
    }
}
