﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine Engine) 
        {
            this.Model = model;
            this.Engine = Engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }

        public int Weight { get; set; }
        public string Color { get; set; }


        public override string ToString()
        {
            string weight = Weight == 0 ? "n/a" : Weight.ToString();
            string color = Color ?? "n/a";

            StringBuilder sb = new();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.ToString()}");
            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {color}");

            return sb.ToString().TrimEnd();
        }

    }
}
