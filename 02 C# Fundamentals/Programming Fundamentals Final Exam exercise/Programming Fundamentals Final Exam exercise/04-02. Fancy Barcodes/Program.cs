using System.Text.RegularExpressions;

namespace _04_02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(@#{1,})(?<barcodeName>[A-Z][a-z0-9A-Z]{4,}[A-Z])(@#{1,})";
            
            int n = int.Parse(Console.ReadLine());
            string groupNumsAsString = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(patern);
                MatchCollection matches = regex.Matches(input);
                if (regex.IsMatch(input))
                {
                    string barcode = regex.Match(input).ToString();
                    char[] chars = barcode.ToCharArray();
                    bool isZeroGroup = true;

                    for (int j = 0; j < chars.Length; j++)
                    {
                        if (chars[j] >= 48 && chars[j] <= 57)
                        {
                            isZeroGroup = false;
                            groupNumsAsString += chars[j];
                        }
                    }
                    if (isZeroGroup)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {groupNumsAsString}");
                        groupNumsAsString = string.Empty;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

        }
    }
}