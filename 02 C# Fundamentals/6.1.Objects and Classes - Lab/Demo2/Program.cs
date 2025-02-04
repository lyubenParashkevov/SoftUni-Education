using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songInfo = Console.ReadLine().Split("_", StringSplitOptions.RemoveEmptyEntries);

                string typeList = songInfo[0];
                string name = songInfo[1];
                string duration = songInfo[2];

                Song song = new Song(typeList, name, duration);
                songs.Add(song);
            }

            string typeListOrAll = Console.ReadLine();

            if (typeListOrAll == "all")
            {
                
            }

            else
            {
                Song PrintSongOfType(typeListOrAll, songs);
            }
        }
    }

    public class Song
    {
        public Song(string typeList, string name, string duration)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Duration = duration;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }

        static void PrintAll(List<Song> songs)
        {
            foreach (Song s in songs)
            {
                Console.WriteLine(s.Name);
            }
        }

        static void PrintSongOfType(string typeListOrAll, List<Song> songs)
        {
            foreach (Song s in songs.Where(s => s.TypeList == typeListOrAll))
            {
                Console.WriteLine(s.Name);
            }
        }
    }

}