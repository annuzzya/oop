using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DormitoryLab.Models
{
    public class Resident
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomNumber { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public DateTime ResidenceStart { get; set; } 
        public DateTime ResidenceEnd { get; set; }

        [JsonIgnore]
        public string FullName => $"{LastName} {FirstName}";

        public override string ToString()
        {
            return $"{LastName} {FirstName} (Кімната: {RoomNumber}, Факультет: {Faculty})";
        }
    }
}
