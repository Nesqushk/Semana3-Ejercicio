using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Farm
{
    public List<Plant> Plants { get; private set; } = new List<Plant>();
    public int FieldSize { get; private set; } = 2;
    public int ExpandCost { get; private set; } = 10;

    public void ExpandFarm()
    {
        FieldSize++;
        ExpandCost += 10;
    }

    public bool AddPlant(Plant plant)
    {
        if (Plants.Count < FieldSize)
        {
            Plants.Add(plant);
            return true;
        }
        return false;
    }

    public List<Plant> GetReadyToHarvest()
    {
        return Plants.FindAll(p => p.IsReadyToHarvest);
    }

    public void PassTurn()
    {
        foreach (var plant in Plants)
        {
            plant.PassTurn();
        }
    }
}

