using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Mountain : GeographicalObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double HighestPoint { get; set; }

        public Mountain(double x, double y, string name, string description, double highestPoint)
        {
            X = x;
            Y = y;
            Name = name;
            Description = description;
            HighestPoint = highestPoint;
        }

        public string GetInfo()
        {
            return $"Mountain name: {Name} \nLocation: ({X}, {Y}) \nDescription: {Description} \nPeak: {HighestPoint} m";
        }
    }
}
