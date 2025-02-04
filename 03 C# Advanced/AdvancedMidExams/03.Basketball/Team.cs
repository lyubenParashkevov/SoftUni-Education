using System;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> playerList = new List<Player>();
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> PlayerList { get; set; }

        public int Count
        { get { return PlayerList.Count; } }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Position == null)
            {
                return "Invalid player's information.";
            }
           
            else if (PlayerList.Count == OpenPositions)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                PlayerList.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }
        public bool RemovePlayer(string name)
        {
            foreach (Player player in PlayerList.Where(p => p.Name == name))
            {
                PlayerList.Remove(player);
                OpenPositions++;
                return true;
            }
            return false;
        }
        public int RemovePlayerByPosition(string position)
        {
            int counter = 0;
            foreach (Player player in PlayerList.Where(p => p.Position == position))
            {
                PlayerList.Remove(player);
                OpenPositions++;
                counter++; 
            }
            if (counter > 0)
            {
                return counter;
            }
            else { return 0; }
        }

        public Player RetirePlayer(string name)
        {
            foreach (var player in PlayerList.Where(p => p.Name == name))
            {
                player.Retired = true;
                return player;
            }
            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awarded = new List<Player>();

            foreach (var player in PlayerList.Where(p => p.Games == games))
            {
                awarded.Add(player);
            }
            return awarded;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in PlayerList.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
