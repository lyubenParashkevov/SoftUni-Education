

using P02_FootballBetting.Data;

public class StartUp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Started...");

		try
		{
			using FootballBettingContext dbContext = new FootballBettingContext();

			dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();

            Console.WriteLine("Created");
		}
		catch (Exception e)
		{

            Console.WriteLine(e.Message);
		}
    }
}