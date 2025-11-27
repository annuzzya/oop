using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_task5_1
{
    public class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Developer";
        }
        public override void FillWorkDay()
        {
            WorkDay = "";

            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }
}
