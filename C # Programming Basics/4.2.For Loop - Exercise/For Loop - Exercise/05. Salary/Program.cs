﻿using System;

namespace _05._Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int numTabs = int.Parse(Console.ReadLine());            
            int salary = int.Parse(Console.ReadLine());
            string sites = string.Empty;           

            for (int i = 0; i < numTabs; i++)
            {
               sites = Console.ReadLine();               
                if (sites == "Facebook")
                {
                    salary -= 150;
                }
                else if (sites == "Instagram")
                {
                    salary -= 100;
                }
                else if (sites == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }

            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }    
        }
                                  
    }
}
