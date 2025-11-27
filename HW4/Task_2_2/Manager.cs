using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_task5_1
{
    public class Manager : Worker
    {
        private Random _random = new Random();

        public Manager(string name) : base(name)
        {
            Position = "Manager";
        }

        public override void FillWorkDay()
        {
            WorkDay = "";

            int callsCount1 = _random.Next(1, 11);
            for (int i = 0; i < callsCount1; i++)
            {
                Call();
            }

            Relax();

            int callsCount2 = _random.Next(1, 6);
            for (int i = 0; i < callsCount2; i++)
            {
                Call();
            }
        }
    }
}
