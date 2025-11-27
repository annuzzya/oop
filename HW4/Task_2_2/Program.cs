using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_task5_1
{
    class Program
    {
        static List<Team> teams = new List<Team>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Create a new team");
                Console.WriteLine("2. Add an employee to the team");
                Console.WriteLine("3. Display information about a team");
                Console.WriteLine("4. Display detailed information about a team");

                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateTeam();
                        break;
                    case "2":
                        AddWorkerToTeam();
                        break;
                    case "3":
                        ShowTeamInfo();
                        break;
                    case "4":
                        ShowDetailedTeamInfo();
                        break;
                    default:
                        Console.WriteLine("Incorrect choice. Try again");
                        break;
                }
            }
        }

        static void CreateTeam()
        {
            Console.Write("Enter the name of the new team: ");
            string teamName = Console.ReadLine();

            if (teams.Any(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("A team with that already exists");
            }
            else
            {
                Team newTeam = new Team(teamName);
                teams.Add(newTeam);
                Console.WriteLine($"Team with name '{teamName}' successfuly created!");
            }
        }

        static void AddWorkerToTeam()
        {
            Console.Write("Enter the name of the team you want to add employees: ");
            string teamName = Console.ReadLine();

            Team targetTeam = teams.FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase));

            if (targetTeam == null)
            {
                Console.WriteLine("Team not found");
                return;
            }

            Console.Write("Enter the name of the new employee: ");
            string workerName = Console.ReadLine();

            Console.Write("Choose position (1 - Developer, 2 - Manager): ");
            string positionChoice = Console.ReadLine();

            Worker newWorker = null;
            if (positionChoice == "1")
            {
                newWorker = new Developer(workerName);
            }
            else if (positionChoice == "2")
            {
                newWorker = new Manager(workerName);
            }
            else
            {
                Console.WriteLine("Incorrect position");
                return;
            }

            targetTeam.AddWorker(newWorker);
        }

        static void ShowTeamInfo()
        {
            Console.Write("Enter the name of the team to view: ");
            string teamName = Console.ReadLine();
            Team targetTeam = teams.FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase));

            if (targetTeam != null)
            {
                targetTeam.ShowTeamInfo();
            }
            else
            {
                Console.WriteLine("Team not found");
            }
        }

        static void ShowDetailedTeamInfo()
        {
            Console.Write("Enter the name of the team to view detailed information: ");
            string teamName = Console.ReadLine();
            Team targetTeam = teams.FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase));

            if (targetTeam != null)
            {
                targetTeam.ShowDetailedTeamInfo();
            }
            else
            {
                Console.WriteLine("Team not found");
            }
        }
    }
}
