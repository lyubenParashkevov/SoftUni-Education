using System;

namespace _0._5_Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double penPack = 5.80;
            double markerPack = 7.20;
            double preparation = 1.20;
            int numPenPack = int.Parse(Console.ReadLine());
            int numMarkerPack = int.Parse(Console.ReadLine());
            double numPreparation = double.Parse(Console.ReadLine());  
            double percent = double.Parse(Console.ReadLine()) / 100;
            double fullSum = numPenPack * penPack + numMarkerPack * markerPack + numPreparation * preparation;
            double finalSum = fullSum - fullSum * percent;
            Console.WriteLine(finalSum);
        }
    }
}
