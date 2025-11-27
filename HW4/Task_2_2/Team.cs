using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_task5_1
{
    public class Team
    {
        public string TeamName { get; private set; }

        private List<Worker> _workers = new List<Worker>();

        public Team(string name)
        {
            TeamName = name;
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
            Console.WriteLine($"Employee {worker.Name} has been added to the team '{TeamName}'.");
        }

        public void ShowTeamInfo()
        {
            Console.WriteLine($"\nTeam: {TeamName}");
            foreach (var worker in _workers)
            {
                Console.WriteLine($"- {worker.Name} ({worker.Position})");
            }
        }

        public void ShowDetailedTeamInfo()
        {
            Console.WriteLine($"\n Detailed information about team: {TeamName}");
            foreach (var worker in _workers)
            {
                worker.FillWorkDay();
                Console.WriteLine($"- {worker.Name} ({worker.Position}) - {worker.WorkDay}");
            }
        }
    }
}
