using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_task5_1
{
    public abstract class Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string WorkDay { get; protected set; } 
        public Worker(string name)
        {
            this.Name = name;
            this.Position = ""; 
            this.WorkDay = "";
        }
        public void Call()
        {
            Console.WriteLine($"{Name} is callind...");
            WorkDay += " Call "; 
        }

        public void WriteCode()
        {
            Console.WriteLine($"{Name} writes code...");
            WorkDay += " Write code ";
        }

        public void Relax()
        {
            Console.WriteLine($"{Name} relaxing...");
            WorkDay += " Relax ";
        }
        public abstract void FillWorkDay();
    }
}
