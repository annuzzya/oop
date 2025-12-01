using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DormitoryApp
{
    public class SaxSearchStrategy : IResidentSearchStrategy
    {
        public List<Resident> Search(string xmlFilePath, SearchCriteria criteria)
        {
            var results = new List<Resident>();
            var settings = new XmlReaderSettings { IgnoreWhitespace = true };

            using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Resident")
                    {
                        if (MatchesCriteria(reader, criteria))
                        {
                            results.Add(ParseResidentFromReader(reader));
                        }
                    }
                }
            }
            return results;
        }

        private bool MatchesCriteria(XmlReader reader, SearchCriteria criteria)
        {
            if (!string.IsNullOrWhiteSpace(criteria.Name) &&
                !reader.GetAttribute("Name")?.Contains(criteria.Name) == true) return false;

            if (!string.IsNullOrWhiteSpace(criteria.Faculty) && criteria.Faculty != "Всі" &&
                reader.GetAttribute("Faculty") != criteria.Faculty) return false;

            if (!string.IsNullOrWhiteSpace(criteria.Department) &&
                !reader.GetAttribute("Department")?.Contains(criteria.Department) == true) return false;

            if (criteria.Course.HasValue &&
                reader.GetAttribute("Course") != criteria.Course.Value.ToString()) return false;

            if (!string.IsNullOrWhiteSpace(criteria.Room) &&
                reader.GetAttribute("Room") != criteria.Room) return false;

            return true;
        }

        private Resident ParseResidentFromReader(XmlReader reader)
        {
            return new Resident
            {
                Name = reader.GetAttribute("Name"),
                Faculty = reader.GetAttribute("Faculty"),
                Department = reader.GetAttribute("Department"),
                Course = int.Parse(reader.GetAttribute("Course") ?? "0"),
                Room = reader.GetAttribute("Room"),
                ResidenceStart = DateTime.Parse(reader.GetAttribute("ResidenceStart") ?? DateTime.MinValue.ToString()),
                ResidenceEnd = DateTime.Parse(reader.GetAttribute("ResidenceEnd") ?? DateTime.MaxValue.ToString()),
                ContractNumber = reader.GetAttribute("ContractNumber")
            };
        }
    }
}
