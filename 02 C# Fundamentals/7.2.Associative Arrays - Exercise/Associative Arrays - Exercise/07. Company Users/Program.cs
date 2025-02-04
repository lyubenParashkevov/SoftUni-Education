namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyData = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] companyAndEmployees = input.Split(" -> ").ToArray();
                string companyName = companyAndEmployees[0];
                string companyId = companyAndEmployees[1];

                if (!companyData.ContainsKey(companyName))
                {
                    companyData.Add(companyName, new List<string>());
                    companyData[companyName].Add(companyId);
                }

                if (!companyData[companyName].Contains(companyId))
                {
                    companyData[companyName].Add(companyId);
                }

            }

            foreach (var company in companyData)
            {
                Console.WriteLine(company.Key);
                for (int i = 0; i < company.Value.Count; i++)
                {
                    Console.WriteLine($"-- {company.Value[i]}");
                }

            }

        }
    }
}