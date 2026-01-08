using P02_FootballBetting.Data.Models;
using System;


namespace P02_FootballBetting;
public class StartUp
{
    public static void Main(string[] args)
    {
        using FootballBettingContext dbContext = new FootballBettingContext();

        Console.WriteLine("Creating...new Base");

        try
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Console.WriteLine("Created");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

       


    }
}