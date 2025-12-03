using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryLab.Models;

namespace DormitoryLab.Services
{
    public class ValidationService
    {
        public bool ValidateResident(Resident resident, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(resident.FirstName) || string.IsNullOrWhiteSpace(resident.LastName))
            {
                errorMessage = "Ім'я та Прізвище не можуть бути порожніми.";
                return false;
            }

            if (resident.RoomNumber <= 0)
            {
                errorMessage = "Номер кімнати має бути більше 0.";
                return false;
            }

            if (resident.Course < 1 || resident.Course > 6)
            {
                errorMessage = "Курс має бути від 1 до 6.";
                return false;
            }

            return true;
        }
    }
}
