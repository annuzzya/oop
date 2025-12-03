using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryLab.Models
{
    public class Dorm
    {
        public List<Resident> Residents { get; set; } = new List<Resident>();

        public void AddResident(Resident resident)
        {
            Residents.Add(resident);
        }

        public void EditResident(Resident oldResident, Resident newResident)
        {
            var index = Residents.IndexOf(oldResident);
            if (index != -1)
            {
                Residents[index] = newResident;
            }
        }

        public void RemoveResident(Resident resident)
        {
            Residents.Remove(resident);
        }
    }
}