using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GameManager
{
    public int Money { get; private set; }
    public Farm Farm { get; private set; } = new Farm();

    public GameManager(int initialMoney)
    {
        Money = initialMoney;
    }

    public void BuySeed(Plant plant)
    {
        if (Money >= plant.SeedCost && Farm.AddPlant(plant))
        {
            Money -= plant.SeedCost;
            Console.WriteLine($"Plantaste {plant.Name}.");
        }
        else
        {
            Console.WriteLine("No tienes dinero o espacio suficiente.");
        }
    }

    public void NextTurn()
    {
        Farm.PassTurn();
        var ready = Farm.GetReadyToHarvest();
        if (ready.Count > 0)
        {
            Console.WriteLine($"Hay {ready.Count} plantas listas para cosechar.");
        }
    }

    public void Harvest()
    {
        var ready = Farm.GetReadyToHarvest();
        foreach (var plant in ready)
        {
            int profit = plant.Fruits * plant.ProductValue;
            Money += profit;
            Farm.Plants.Remove(plant);
            Console.WriteLine($"Cosechaste {plant.Name} y ganaste ${profit}.");
        }
    }

    public void ExpandFarm()
    {
        if (Money >= Farm.ExpandCost)
        {
            Money -= Farm.ExpandCost;
            Farm.ExpandFarm();
            Console.WriteLine($"Granja expandida. Espacios: {Farm.FieldSize}");
        }
        else
        {
            Console.WriteLine("Dinero insuficiente para expandir la granja.");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine($"\nDinero: {Money}");
        Console.WriteLine($"Espacios ocupados: {Farm.Plants.Count}/{Farm.FieldSize}");
        foreach (var plant in Farm.Plants)
        {
            Console.WriteLine($" - {plant.Name} ({plant.TurnsAlive}/{plant.LifeTime} turnos)");
        }
    }
}


