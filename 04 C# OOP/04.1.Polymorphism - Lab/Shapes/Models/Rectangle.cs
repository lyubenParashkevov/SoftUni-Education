using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; private set; }
        public double Height { get; private set; }
        public override double CalculateArea() => Width * Height;      
        
        public override double CalculatePerimeter() => 2 * Height + 2 * Width;

       //public override string Draw()
       // {
       //     return $"Drawing {nameof(Rectangle)}";
       // }
    }
}
