using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DormitoryLab.Models;

namespace DormitoryLab.Services
{
    public class JsonFileManager
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        public string Serialize(Dorm dorm)
        {
            return JsonSerializer.Serialize(dorm, _options);
        }

        public Dorm Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Dorm>(json) ?? new Dorm();
        }

        public void Save(string path, Dorm dorm)
        {
            string json = Serialize(dorm);
            File.WriteAllText(path, json);
        }

        public Dorm Load(string path)
        {
            if (!File.Exists(path)) return new Dorm();
            string json = File.ReadAllText(path);
            return Deserialize(json);
        }
    }
}
