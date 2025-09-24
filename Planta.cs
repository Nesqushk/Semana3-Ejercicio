using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Plant
{
    public string Name { get; set; }
    public int LifeTime { get; set; }       // Turnos para crecer
    public int Fruits { get; set; }         // Cantidad de frutos
    public int SeedCost { get; set; }       // Costo de semilla
    public int ProductValue { get; set; }   // Valor de fruto
    public int TurnsAlive { get; set; }     // Turnos transcurridos

    public bool IsReadyToHarvest => TurnsAlive >= LifeTime;

    public void PassTurn()
    {
        TurnsAlive++;
    }
}