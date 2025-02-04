using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine Engine, Cargo Cargo, Tire[] Tires)
        {
            this.Model = model;
            this.Engine = Engine;
            this.Cargo = Cargo;
            this.Tires = Tires;
        }
        public string Model { get; set; }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public Cargo Cargo { get {  return cargo; } set {  cargo = value; } }
        public Tire[] Tires { get {  return tires; } set {  tires = value; } }
    }
}
