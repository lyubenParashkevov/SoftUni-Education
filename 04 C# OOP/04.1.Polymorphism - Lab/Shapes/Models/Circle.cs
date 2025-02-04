using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }
        public override double CalculateArea() => Math.PI * Radius * Radius;
        

        public override double CalculatePerimeter() => 2 * Math.PI * Radius;


        //public override string Draw()
        //{
        //    return $"Drawing {nameof(Circle)}";
        //}

    }
}
