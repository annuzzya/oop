using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_1
{
    public class Mountain : GeoObject
    {
        public double HighestPoint { get; set; }

        public Mountain(double x, double y, string name, string description, double highestPoint)
            : base(x, y, name, description)
        {
            HighestPoint = highestPoint;
        }

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return $"{baseInfo}\nPeak: {HighestPoint} m";
        }
    }
}
