using System;

namespace _04._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.  Четем от конзолата:
            //1.1Възрастта на Лили - цяло число в интервала [1...77]
            int ageLily = int.Parse(Console.ReadLine());
            //1.2Цената на пералнята - число в интервала
            double washingMashinePrice = double.Parse(Console.ReadLine());
            //1.3Единична цена на играчка -цяло число в интервала[0...40]
            int toyPrice = int.Parse(Console.ReadLine());
            //2.създаваме променливи за пари ,  играчки  обща сума , четни години, нечетни години.
            double money = 0;
            double toyMoney = 0;
            double tottalSum = 0;
            
            

            for (int i = 1; i <= ageLily; i++)
            {
                if (i % 2 == 0)
                {
                    
                    money += i * 5 - 1;
                }
                else
                {
                    
                    toyMoney += toyPrice;
                }
            }
            tottalSum = money + toyMoney;
            if (tottalSum >= washingMashinePrice)
            {
                Console.WriteLine($"Yes! {tottalSum - washingMashinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMashinePrice - tottalSum:f2}");
               
            }

            // на всеки 2 години + 10лв и - 1лв които взема брат и. (9 лв)  2,4,6,8,...
            // на всеки 2 нечетни години получава играчка . 1,3,5,7,9...  после гипродава и парите добавя в общатасума

            //3. Ако парите са >= от парите за пералня:   o	"Yes! {N:f2}" - където N е остатъка пари след покупката
            //   Ако парите са < от парите за пералня:     o	"No! {М:f2}" - където M е сумата, която не достига

        }
    }
}
