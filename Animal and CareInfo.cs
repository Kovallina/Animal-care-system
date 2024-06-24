using System;

namespace Система_догляду_за_тваринами
{
    internal class Animal_and_CareInfo
    {
        public class Animal
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Breed { get; set; }
            public int Age { get; set; }
            public string HealthStatus { get; set; }
            public string Description { get; set; }
        }

        public class CareInfo
        {
            public DateTime Date { get; set; }
            public string Description { get; set; }
        }
    }
}
