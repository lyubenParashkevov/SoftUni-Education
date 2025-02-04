
int number = int.Parse(Console.ReadLine());
PrintResult(number);


void PrintResult(int number)
{
    try
    {
        if (number < 0)
        {
            throw new ArgumentException("Invalid number.");
        }

        Console.WriteLine(Math.Sqrt(number));
    }
    catch (ArgumentException ex)
    {

        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Goodbye.");

    }


}