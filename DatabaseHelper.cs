using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Система_догляду_за_тваринами
{
    public static class DatabaseHelper
    {
        private static readonly string dbFilePath = "animals_db.json";

        public static List<Animal> LoadAnimals()
        {
            if (File.Exists(dbFilePath))
            {
                var json = File.ReadAllText(dbFilePath);
                return JsonConvert.DeserializeObject<List<Animal>>(json) ?? new List<Animal>();
            }
            return new List<Animal>();
        }

        public static void SaveAnimals(List<Animal> animals)
        {
            var json = JsonConvert.SerializeObject(animals, Formatting.Indented);
            File.WriteAllText(dbFilePath, json);
        }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public string HealthStatus { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
