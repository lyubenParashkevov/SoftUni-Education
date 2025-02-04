using System.ComponentModel.DataAnnotations;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> rеgular = new HashSet<string>();

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }
      
                else
                {

                    if (Char.IsDigit(guest[0]))
                    {
                        vip.Add(guest);
                    }
                    else
                    {
                        rеgular.Add(guest);
                    }
                }
            }

            while (true)
            {
                string guest = Console.ReadLine();
                if (guest == "END")
                {
                    break;
                }

                if (vip.Contains(guest))
                {
                    vip.Remove(guest);
                }
                else
                {
                    rеgular.Remove(guest);
                }
            }
            int count = vip.Count + rеgular.Count;
            Console.WriteLine(count);
            if (vip.Count > 0)
            {
                foreach (string guest in vip)
                {
                    Console.WriteLine(guest);
                }
            }
            if (rеgular.Count > 0)
            {
                foreach (string guest in rеgular)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}