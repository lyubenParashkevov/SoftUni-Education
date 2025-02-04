using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
             FullName = fullName;
            CanRace = false;
            
        }
        public string FullName
        {
            get { return fullName; }
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value; 
            }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set 
            { 
                car = value; 

                if (car == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins += 1;
        }

        public override string ToString()
        {
            return $"Pilot {fullName } has {NumberOfWins } wins.";   // StringBuilder?
        }
    }
}
