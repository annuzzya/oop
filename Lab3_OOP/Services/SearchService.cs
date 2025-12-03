using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryLab.Models;

namespace DormitoryLab.Services
{
    public class SearchService
    {
        public List<Resident> SearchBySurname(List<Resident> list, string surname)
        {
            return list.Where(r => r.LastName.Contains(surname, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Resident> SearchByRoom(List<Resident> list, int room)
        {
            return list.Where(r => r.RoomNumber == room).ToList();
        }

        public List<Resident> SearchByFaculty(List<Resident> list, string faculty)
        {
            return list.Where(r => r.Faculty.Contains(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Resident> SearchByCourse(List<Resident> list, int course)
        {
            return list.Where(r => r.Course == course).ToList();
        }
    }
}
