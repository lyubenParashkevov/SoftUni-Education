namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, int>> vlogerSet = new();

            while (true)
            {
                string[] vlogerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vlogerName = vlogerInfo[0];

                if (vlogerName == "Statistics")
                {
                    break;
                }

                string command = vlogerInfo[1];

                if (command == "joined")
                {
                    if (!vlogerSet.ContainsKey(vlogerName))
                    {
                        vlogerSet.Add(vlogerName, new SortedDictionary<string, int>());
                    }
                }

                else  // == folowed
                {
                    string folower = vlogerInfo[0];
                    vlogerName = vlogerInfo[2];

                    if (vlogerSet.ContainsKey(folower) && vlogerSet.ContainsKey(vlogerName) && folower != vlogerName
                        && !vlogerSet[vlogerName].ContainsKey(folower))
                    {
                        vlogerSet[vlogerName].Add(folower, 0);
                        vlogerSet[vlogerName][folower]++;
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogerSet.Count} vloggers in its logs.");

            foreach (var v in vlogerSet)
            {
                Console.WriteLine(v.Key);

            }
        }
    }
}
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//
//Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new();
//
//string input = string.Empty;
//while ((input = Console.ReadLine()) != "Statistics")
//{
//    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
//
//    string command = tokens[1];
//
//    if (command == "joined")
//    {
//        string vloggerName = tokens[0];
//
//        if (!vloggers.ContainsKey(vloggerName))
//        {
//            vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
//            vloggers[vloggerName].Add("followers", new HashSet<string>());
//            vloggers[vloggerName].Add("following", new HashSet<string>());
//        }
//    }
//    else if (command == "followed")
//    {
//        string vlogger = tokens[0];
//        string vloggerToFollow = tokens[2];
//
//        if (vloggers.ContainsKey(vlogger) &&
//            vloggers.ContainsKey(vloggerToFollow) &&
//            vlogger != vloggerToFollow)
//        {
//            vloggers[vlogger]["following"].Add(vloggerToFollow);
//            vloggers[vloggerToFollow]["followers"].Add(vlogger);
//        }
//    }
//}
//
//int count = 1;
//
//Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
//
//Dictionary<string, Dictionary<string, HashSet<string>>> orderedVloggers = vloggers
//    .OrderByDescending(v => v.Value["followers"].Count)
//    .ThenBy(v => v.Value["following"].Count)
//    .ToDictionary(v => v.Key, v => v.Value);
//
//foreach (var vlogger in orderedVloggers)
//{
//    Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
//
//    if (count == 1)
//    {
//        //Try SortedSet for vloggers 
//        List<string> orderedFollowers = vlogger.Value["followers"]
//            .OrderBy(f => f)
//            .ToList();
//
//        foreach (var follower in orderedFollowers)
//        {
//            Console.WriteLine($"*  {follower}");
//        }
//    }
//
//    count++;
//}