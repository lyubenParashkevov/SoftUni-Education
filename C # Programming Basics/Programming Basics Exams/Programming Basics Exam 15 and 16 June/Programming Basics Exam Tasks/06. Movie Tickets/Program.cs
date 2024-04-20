using System;

namespace _06._Movie_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int simbol1 = 0;
            int simbol2 = 0;
            int simbol3 = 0;
            int simbol4 = 0;


            for ( simbol1 = a1; simbol1 <= a2 - 1; simbol1++)
            {
                for (simbol2 = 1; simbol2 <= n - 1;simbol2 ++)
                {
                    for (simbol3 = 1; simbol3 <= n / 2 - 1;simbol3 ++)
                    {
                        simbol4 = simbol1;
                        char ch = (char)simbol1;

                        if (simbol1 % 2 != 0 && (simbol2 + simbol3 + simbol4) % 2 != 0)
                        {
                            Console.WriteLine($"{ch}-{simbol2}{simbol3}{simbol4}");
                        }
                    }
                }
            }
        }
    }
}
