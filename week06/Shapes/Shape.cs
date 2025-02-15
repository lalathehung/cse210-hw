using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        private string _color;

        public string GetColor()
        {
            return _color;
        }
        public Shape(string color)
        {
            _color = color;
        }
        public void SetColor(string value)
        {
            _color = value;
        }

        public abstract double GetArea();
    }
}