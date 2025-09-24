using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        GameManager game = new GameManager(100);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Comprar semilla");
            Console.WriteLine("2. Pasar turno");
            Console.WriteLine("3. Cosechar");
            Console.WriteLine("4. Expandir granja");
            Console.WriteLine("5. Ver estado");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Elige una semilla:");
                    Console.WriteLine("1. Tomate (20$)");
                    Console.WriteLine("2. Papa (15$)");
                    Console.WriteLine("3. Zanahoria (10$)");

                    string choice = Console.ReadLine();
                    Plant selected = null;

                    if (choice == "1")
                        selected = new Plant { Name = "Tomate", LifeTime = 3, Fruits = 5, SeedCost = 20, ProductValue = 10 };
                    else if (choice == "2")
                        selected = new Plant { Name = "Papa", LifeTime = 2, Fruits = 3, SeedCost = 15, ProductValue = 8 };
                    else if (choice == "3")
                        selected = new Plant { Name = "Zanahoria", LifeTime = 1, Fruits = 2, SeedCost = 10, ProductValue = 5 };

                    if (selected != null) game.BuySeed(selected);
                    break;

                case "2":
                    game.NextTurn();
                    break;

                case "3":
                    game.Harvest();
                    break;

                case "4":
                    game.ExpandFarm();
                    break;

                case "5":
                    game.ShowStatus();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}

