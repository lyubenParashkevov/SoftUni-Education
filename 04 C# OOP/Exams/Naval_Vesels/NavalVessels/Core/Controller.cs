using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vessels = new VesselRepository();
        private List<ICaptain> captains = new List<ICaptain> ();
        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain (fullName);
            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);

        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;
            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if(vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            
            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured,vesselType, name);
            }

            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel,vesselType, name, mainWeaponCaliber, speed);
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if(vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);
            return captain.Report();

        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName); 
            return vessel.ToString();
        }

       public string ToggleSpecialMode(string vesselName)
       {
           IVessel vessel = vessels.FindByName(vesselName);
           if (vessel.GetType().Name == nameof(Battleship))
           {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
           }
       
           else if (vessel.GetType().Name == nameof(Submarine))
           {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
       
           else
           {
               return string.Format(OutputMessages.VesselNotFound, vesselName);
           }
       }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel is null)
            {
                return string.Format(OutputMessages.VesselNotFound,vesselName);
            }
            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackerVessel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if(attackerVessel is null || defendingVessel is null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackerVessel.Name);
            }

            if (attackerVessel.ArmorThickness == 0 || defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackerVessel.Name);
            }

            attackerVessel.Attack(defendingVessel);
            attackerVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVessel.Name, attackerVessel.Name, defendingVessel.ArmorThickness);
        }

      
        

       

        
    }
}
