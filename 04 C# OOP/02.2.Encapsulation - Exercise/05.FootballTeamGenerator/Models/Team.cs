﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        

        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.AverageStat);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        } 

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if (player != null)
            {
                throw new ArgumentException($"Player {player.Name} is not in {this.Name} team.");
            }
            players.Remove(player);
        }

        
    }
}
