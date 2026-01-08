
using P01_StudentSystem.Data;

public class StartUp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Creating...");

        try
        {
            using StudentSystemContext dbContext = new StudentSystemContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Console.WriteLine("Done");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
       
    }
}

