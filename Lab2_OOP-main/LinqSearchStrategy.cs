using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DormitoryApp
{
    public class LinqSearchStrategy : IResidentSearchStrategy
    {
        public List<Resident> Search(string xmlFilePath, SearchCriteria criteria)
        {
            var doc = XDocument.Load(xmlFilePath);

            // Використовуємо LINQ-запит для фільтрації
            var query = from resident in doc.Descendants("Resident")
                        where (string.IsNullOrWhiteSpace(criteria.Name) ||
                               resident.Attribute("Name")?.Value.Contains(criteria.Name) == true)
                        where (string.IsNullOrWhiteSpace(criteria.Faculty) || criteria.Faculty == "Всі" ||
                               resident.Attribute("Faculty")?.Value == criteria.Faculty)
                        where (string.IsNullOrWhiteSpace(criteria.Department) ||
                               resident.Attribute("Department")?.Value.Contains(criteria.Department) == true)
                        where (!criteria.Course.HasValue ||
                               resident.Attribute("Course")?.Value == criteria.Course.Value.ToString())
                        where (string.IsNullOrWhiteSpace(criteria.Room) ||
                               resident.Attribute("Room")?.Value == criteria.Room)
                        select new Resident
                        {
                            Name = resident.Attribute("Name")?.Value,
                            Faculty = resident.Attribute("Faculty")?.Value,
                            Department = resident.Attribute("Department")?.Value,
                            Course = int.Parse(resident.Attribute("Course")?.Value ?? "0"),
                            Room = resident.Attribute("Room")?.Value,
                            ResidenceStart = DateTime.Parse(resident.Attribute("ResidenceStart")?.Value ?? DateTime.MinValue.ToString()),
                            ResidenceEnd = DateTime.Parse(resident.Attribute("ResidenceEnd")?.Value ?? DateTime.MaxValue.ToString()),
                            ContractNumber = resident.Attribute("ContractNumber")?.Value
                        };

            return query.ToList();
        }
    }
}
