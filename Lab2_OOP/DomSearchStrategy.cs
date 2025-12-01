using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DormitoryApp
{
    public class DomSearchStrategy : IResidentSearchStrategy
    {
        public List<Resident> Search(string xmlFilePath, SearchCriteria criteria)
        {
            var results = new List<Resident>();
            var doc = new XmlDocument();
            doc.Load(xmlFilePath);

            // Будуємо XPath-запит динамічно на основі критеріїв
            string xpath = "//Resident";
            var conditions = new List<string>();

            if (!string.IsNullOrWhiteSpace(criteria.Name))
                conditions.Add($"contains(@Name, '{criteria.Name}')");
            if (!string.IsNullOrWhiteSpace(criteria.Faculty) && criteria.Faculty != "Всі")
                conditions.Add($"@Faculty = '{criteria.Faculty}'");
            if (!string.IsNullOrWhiteSpace(criteria.Department))
                conditions.Add($"contains(@Department, '{criteria.Department}')");
            if (criteria.Course.HasValue)
                conditions.Add($"@Course = '{criteria.Course.Value}'");
            if (!string.IsNullOrWhiteSpace(criteria.Room))
                conditions.Add($"@Room = '{criteria.Room}'");

            if (conditions.Count > 0)
                xpath += $"[{string.Join(" and ", conditions)}]";

            var nodes = doc.SelectNodes(xpath);
            foreach (XmlNode node in nodes)
            {
                results.Add(ParseResidentFromAttributes(node.Attributes));
            }
            return results;
        }

        private Resident ParseResidentFromAttributes(XmlAttributeCollection attributes)
        {
            return new Resident
            {
                Name = attributes["Name"]?.Value,
                Faculty = attributes["Faculty"]?.Value,
                Department = attributes["Department"]?.Value,
                Course = int.Parse(attributes["Course"]?.Value ?? "0"),
                Room = attributes["Room"]?.Value,
                ResidenceStart = DateTime.Parse(attributes["ResidenceStart"]?.Value ?? DateTime.MinValue.ToString()),
                ResidenceEnd = DateTime.Parse(attributes["ResidenceEnd"]?.Value ?? DateTime.MaxValue.ToString()),
                ContractNumber = attributes["ContractNumber"]?.Value
            };
        }
    }
}
