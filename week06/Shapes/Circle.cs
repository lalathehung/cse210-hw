using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double _radius;
        private string _color;
        private double _pi = Math.PI;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }


        public Circle(string color, double radius) : base(color)
        {
            _color = color;
            _radius = radius;
        }

        public override double GetArea()
        {
            double area = _pi * _radius * _radius;
            return Math.Round(area, 2);
        }
    }
}