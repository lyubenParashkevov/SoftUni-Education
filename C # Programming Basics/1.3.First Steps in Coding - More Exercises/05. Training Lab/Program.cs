using System;

namespace _05._Training_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine()) - 1;

            double workPlacesLenght = (int)(lenght / 1.2);
            
            double workPlacesWidth = (int)(width / 0.7);

            double allWorkPlaces = workPlacesLenght * workPlacesWidth - 3; 
            Console.WriteLine(allWorkPlaces);
            

        }
        }
    }
