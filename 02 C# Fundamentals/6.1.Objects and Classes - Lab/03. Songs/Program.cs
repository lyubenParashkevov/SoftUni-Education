using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songNumber = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < songNumber; i++)
            {
                string[] songProperties = Console.ReadLine().Split('_');
                Song song = new Song(songProperties[0], songProperties[1], songProperties[2]);

                songs.Add(song);
            }

            string songType = Console.ReadLine();

            if (songType == "all")
            {

                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }

            else
            {
                foreach (Song song in songs)
                {
                    if (songType == song.TypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }

        public class Song
        {
            public Song(string typeList, string name, string time)
            {
                this.TypeList = typeList;
                this.Name = name;
                this.Time = time;
            }

           public string TypeList { get; set; }
           public string Name { get; set; }
           public string Time { get; set; }
        }
    }
}