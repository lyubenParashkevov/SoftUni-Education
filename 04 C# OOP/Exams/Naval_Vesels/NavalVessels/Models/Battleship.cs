using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double BattleshipArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, BattleshipArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        // void RepairVessel ?
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.SonarMode == true)
            {
                sb.AppendLine($"*Sonar mode: ON");
            }
            else
            {
                sb.AppendLine($"*Sonar mode: OFF");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
