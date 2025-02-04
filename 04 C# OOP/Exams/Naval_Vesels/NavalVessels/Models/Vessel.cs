using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private List<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            Captain = captain;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            targets = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }
        public ICaptain Captain { get; set; }
       //{   
       //    get { return captain; }
       //    set                          
       //    {
       //        captain = value;
       //        if (captain == null)
       //        {
       //            throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
       //        }
       //    }
       //}   
        public double ArmorThickness { get; set; }  

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets 
        { 
            get { return targets; } 
           
        }
        
        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            if (this.Name == nameof(Battleship))
            {
                this.ArmorThickness = 300;
            }
            else
            {
                this.ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine("*Targets: None");
            }
            else
            {
                sb.Append($"*Targets: {string.Join(", ", this.Targets)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
