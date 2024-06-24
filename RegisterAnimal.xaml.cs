using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using static Система_догляду_за_тваринами.Animal_and_CareInfo;

namespace Система_догляду_за_тваринами
{
    public partial class RegisterAnimal : Window
    {
        private string dbFilePath = "animals_db.json";
        private List<Animal> animals;

        public RegisterAnimal()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(dbFilePath))
            {
                var json = File.ReadAllText(dbFilePath);
                animals = JsonConvert.DeserializeObject<List<Animal>>(json) ?? new List<Animal>();
            }
            else
            {
                animals = new List<Animal>();
            }
        }

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(animals, Formatting.Indented);
            File.WriteAllText(dbFilePath, json);
        }

        private void SaveAnimal_Click(object sender, RoutedEventArgs e)
        {
            var animal = new Animal
            {
                Name = NameTextBox.Text,
                Type = TypeTextBox.Text,
                Breed = BreedTextBox.Text,
                Age = int.Parse(AgeTextBox.Text),
                HealthStatus = HealthStatusTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            animals.Add(animal);
            SaveData();

            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ExitWithoutSaving_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
