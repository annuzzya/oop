using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1
{
    public class River : GeoObject
    {
        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }

        public River(double x, double y, string name, string description, double flowSpeed, double totalLength)
            : base(x, y, name, description)
        {
            FlowSpeed = flowSpeed;
            TotalLength = totalLength;
        }

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();

            return $"{baseInfo}\nRiver flow rate: {FlowSpeed} cm/s \nGeneral length: {TotalLength} km";

        }
    }
}
