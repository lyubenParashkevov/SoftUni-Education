using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

       public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            set
            {
                if(CheckAverageStatValue(value))
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            set
            {
                if (CheckAverageStatValue(value))
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                if (CheckAverageStatValue(value))
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            set
            {
                if (CheckAverageStatValue(value))
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            set
            {
                if (CheckAverageStatValue(value))
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                shooting = value;
            }
        }

        public double AverageStat => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private bool CheckAverageStatValue(int value) => (value < 0 || value > 100);
        
    }
}
