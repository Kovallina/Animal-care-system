using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Система_догляду_за_тваринами
{
    public partial class SearchAnimal : Window
    {
        private List<Animal> animals;

        public SearchAnimal()
        {
            InitializeComponent();
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            animals = DatabaseHelper.LoadAnimals();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock textBlock = (TextBlock)FindName(textBox.Name.Replace("TextBox", "Placeholder"));
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
            var filteredAnimals = animals.Where(a =>
                (string.IsNullOrEmpty(name) || a.Name.IndexOf(name, System.StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrEmpty(type) || a.Type.IndexOf(type, System.StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrEmpty(breed) || a.Breed.IndexOf(breed, System.StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrEmpty(age) || a.Age.IndexOf(age, System.StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrEmpty(healthStatus) || a.HealthStatus.IndexOf(healthStatus, System.StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrEmpty(description) || a.Description.IndexOf(description, System.StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();

            return filteredAnimals;
        }

        private void SearchResultsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAnimal = (Animal)SearchResultsListView.SelectedItem;
            if (selectedAnimal != null)
            {
                var animalDetailsWindow = new AnimalDetails(selectedAnimal);
                animalDetailsWindow.Show();
                this.Close();
            }
        }

            private void ExitWithList_Click(object sender, RoutedEventArgs e)
        {
            var animalList = new AnimalList();
            animalList.Show();
            this.Close();
        }
    }
}



