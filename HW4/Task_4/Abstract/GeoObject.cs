using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1
{
    public abstract class GeoObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GeoObject(double x, double y, string name, string description)
        {
            X = x;
            Y = y;
            Name = name;
            Description = description;
        }

        public virtual string GetInfo()
        {
            return $"Name: {Name} \nLocation: ({X}, {Y}) \nDescription: {Description}";
        }
    }
}
