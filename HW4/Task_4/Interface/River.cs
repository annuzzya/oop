using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class River : GeographicalObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }
        public River(double x, double y, string name, string description, double flowSpeed, double totalLength)
        {
            X = x;
            Y = y;
            Name = name;
            Description = description;
            FlowSpeed = flowSpeed;
            TotalLength = totalLength;
        }

        public string GetInfo()
        {
            return $"River name: {Name} \nLocation: ({X}, {Y}) \nDescription: {Description} \nFlow speed: {FlowSpeed} cm/s \nTotal Length: {TotalLength} km";
        }
    }
}
