using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKilometer;
    private double traveledDistance;

    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double traveledDistance)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        TraveledDistance = traveledDistance;
        
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKilometer { get; set; }
    public double TraveledDistance { get; set; }

    public void Drive(int kmToDrive)
    {
        if (FuelAmount - FuelConsumptionPerKilometer * kmToDrive >= 0)
        {
            FuelAmount -= FuelConsumptionPerKilometer * kmToDrive;
            TraveledDistance += kmToDrive;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
