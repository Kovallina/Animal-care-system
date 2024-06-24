using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Система_догляду_за_тваринами
{
    public partial class SearchAnimal : Window
    {
        public SearchAnimal()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock textBlock = (TextBlock)FindName(textBox.Name.Replace("TextBox", "TextBlock"));
            textBlock.Visibility = string.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SearchAnimal_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var type = TypeTextBox.Text;
            var breed = BreedTextBox.Text;
            var age = AgeTextBox.Text;
            var healthStatus = HealthStatusTextBox.Text;
            var description = DescriptionTextBox.Text;

            var searchResults = SearchAnimals(name, type, breed, age, healthStatus, description);
            SearchResultsListView.ItemsSource = searchResults;
        }

        private List<Animal> SearchAnimals(string name, string type, string breed, string age, string healthStatus, string description)
        {
            // Приклад даних для пошуку. Замініть цей код вашим джерелом даних.
            var animals = new List<Animal>
            {
                new Animal { Name = "Барсик", Type = "Кішка", Breed = "Сіамська", Age = "3", HealthStatus = "Здоровий", Description = "Лагідний" },
                new Animal { Name = "Шарик", Type = "Собака", Breed = "Бульдог", Age = "5", HealthStatus = "Потребує лікування", Description = "Активний" },
                // Додайте більше даних тут...
            };

            var filteredAnimals = animals.Where(a =>
                (string.IsNullOrEmpty(name) || a.Name.Contains(name)) &&
                (string.IsNullOrEmpty(type) || a.Type.Contains(type)) &&
                (string.IsNullOrEmpty(breed) || a.Breed.Contains(breed)) &&
                (string.IsNullOrEmpty(age) || a.Age.Contains(age)) &&
                (string.IsNullOrEmpty(healthStatus) || a.HealthStatus.Contains(healthStatus)) &&
                (string.IsNullOrEmpty(description) || a.Description.Contains(description))
            ).ToList();

            return filteredAnimals;
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public string HealthStatus { get; set; }
        public string Description { get; set; }
    }
}
