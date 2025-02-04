using Shapes.Models;
using System.Drawing;
using Rectangle = Shapes.Models.Rectangle;

public class StartUp
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle(2, 3);
        Circle circle = new Circle(3);
        Console.WriteLine(rectangle.CalculatePerimeter());
        Console.WriteLine(rectangle.CalculateArea());
        Console.WriteLine(rectangle.Draw());
        Console.WriteLine(circle.Draw());
    }
}