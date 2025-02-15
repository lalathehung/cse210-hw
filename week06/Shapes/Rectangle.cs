using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _length;
        private double _width;
        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Rectangle(string color, double length, double width) : base(color)
        {
            _length = length;
            _width = width;
            _color = color;
        }

        public override double GetArea()
        {
            double area = _width * _length;
            return area;
        }

    }
}