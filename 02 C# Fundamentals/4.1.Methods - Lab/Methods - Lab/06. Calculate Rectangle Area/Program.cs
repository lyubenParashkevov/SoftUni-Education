namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            Console.WriteLine(RectangleArea(length, width));
        }
        static double RectangleArea(double length, double width)
        {
            return length * width;
        }
    }
}