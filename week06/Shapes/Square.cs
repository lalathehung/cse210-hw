using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {
        private double _side;
        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Square(string color, double side) : base(color)
        {
            _side = side;
            _color = color;
        }

        public override double GetArea()
        {
            double area = _side * _side;
            return area;
        }

    }
}