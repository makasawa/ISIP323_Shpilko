using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Shpilko.Model
{
    internal class Game
    {
        static Random rnd = new Random();

        public static Enemy GenerateRandomEnemy(bool isBoss = false)
        {
            if (isBoss)
            {
                int roll = rnd.Next(4);
                switch (roll)
                {
                    case 0: return new GoblinBoss();
                    case 1: return new SkeletBossKova();
                    case 2: return new SkeletBossPest();
                    case 3: return new MagBoss();
                }
            }
            else
            {
                int roll = rnd.Next(3);
                switch (roll)
                {
                    case 0: return new Goblin();
                    case 1: return new Skelet();
                    case 2: return new Mag();
                }
            }
            return null;
        }

        public static void OpenChest(Player player)
        {
            int roll = rnd.Next(3);
            if (roll == 0)
                player.Heal();
            else if (roll == 1)
            {
                int atk = rnd.Next(5, 16);
                player.EquipWeapon($"Меч +{atk}", atk);
            }
            else
            {
                int def = rnd.Next(1, 11);
                player.EquipArmor($"Броня +{def}", def);
            }
        }

        public static void Battle(Player player, Enemy enemy)
        {
            Console.WriteLine($"\nВы столкнулись с {enemy.Name}!");
            while (player.IsAlive() && enemy.IsAlive())
            {
                if (!player.IsFrozen)
                {
                    Console.Write("Ваш ход! 1 - Атака, 2 - Защита: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        int dmg = player.Attack - enemy.Defense;
                        if (dmg < 1) dmg = 1;
                        enemy.CurrentHP -= dmg;
                        Console.WriteLine($"Вы нанесли {dmg} урона {enemy.Name}! HP врага: {enemy.CurrentHP}/{enemy.MaxHP}");
                    }
                    else
                    {
                        if (!player.TryDodge(rnd))
                        {
                            player.BlockNextAttack = true;
                            Console.WriteLine("Уклонение не удалось, блок уменьшит получаемый урон!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы пропускаете ход из-за заморозки!");
                    player.IsFrozen = false;
                }

                if (enemy.IsAlive())
                    enemy.AttackPlayer(player, rnd);
            }

            if (player.IsAlive())
                Console.WriteLine($"Вы победили {enemy.Name}!\n");
            else
                Console.WriteLine("Вы были побеждены...\n");
        }

        public static void MainGame()
        {
            Player player = new Player("Герой", 100, 10, 5);
            int turn = 1;

            while (player.IsAlive())
            {
                Console.WriteLine($"\n=== Ход {turn} ===");
                bool isBossTurn = (turn % 10 == 0);
                bool chestEvent = rnd.Next(2) == 0;

                if (chestEvent && !isBossTurn)
                {
                    Console.WriteLine("Вы нашли сундук!");
                    OpenChest(player);
                }
                else
                {
                    Enemy enemy = GenerateRandomEnemy(isBossTurn);
                    Battle(player, enemy);
                    if (!player.IsAlive()) break;
                }

                turn++;
            }

            Console.WriteLine($"Игра окончена! Вы прошли {turn - 1} ходов.");
        }
    }
}

