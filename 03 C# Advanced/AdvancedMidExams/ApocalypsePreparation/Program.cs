

using System.Runtime;

Queue<int> textile = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));


Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Dictionary<string, int> mediColection = new Dictionary<string, int>();
mediColection.Add("Patch", 0);
mediColection.Add("Bandage", 0);
mediColection.Add("MedKit", 0);
   
int patchCount = 0;  //30
int bandageCount = 0;  // 40
int medKitCount = 0;      // 100  
int tempMedKitCount = 0;

while (medicaments.Count > 0 && textile.Count > 0)
{
    int curMedicament = 0;
    int sum = textile.Peek() + medicaments.Peek();

    if (sum >= 100)
    {
        medKitCount += sum / 100;
        mediColection["MedKit"]++;
        tempMedKitCount += sum / 100;
        textile.Dequeue();
        medicaments.Pop();

        sum -= tempMedKitCount * 100;


        if (sum != 0)
        {
            curMedicament = medicaments.Peek() + sum;
            medicaments.Pop();
            medicaments.Push(curMedicament);
        }
        tempMedKitCount = 0;
    }

    else if (sum == 30)
    {
        textile.Dequeue();
        medicaments.Pop();
        patchCount++;
        mediColection["Patch"]++;

    }

    else if (sum == 40)
    {
        textile.Dequeue();
        medicaments.Pop();
        bandageCount++;
        mediColection["Bandage"]++;
    }

    else
    {
        textile.Dequeue();
        curMedicament = medicaments.Pop() + 10;
        medicaments.Push(curMedicament);
    }

}

if (textile.Count == 0 && medicaments.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}

else if (textile.Count == 0)
{
    Console.WriteLine("Textiles are empty.");
}

else if (medicaments.Count == 0)
{
    Console.WriteLine("Medicaments are empty.");
}

foreach (var medi in mediColection.Where(m => m.Value != 0).OrderByDescending(m => m.Value).ThenBy(m => m.Key))
{
    Console.WriteLine($"{medi.Key} - {medi.Value}");
}

if (textile.Count > 0)
{
    Console.WriteLine($"Textiles left: {string.Join(", ",textile)}");
}
else if (medicaments.Count > 0)
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}