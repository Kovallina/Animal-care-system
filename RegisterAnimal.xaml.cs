using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Система_догляду_за_тваринами
{
    public partial class RegisterAnimal : Window
    {
        private List<Animal> animals;

        public RegisterAnimal()
        {
            InitializeComponent();
            LoadAnimals();
            InitializePlaceholders();
        }

        private void LoadAnimals()
        {
            animals = DatabaseHelper.LoadAnimals();
        }

        private void InitializePlaceholders()
        {
            UpdatePlaceholder(NameTextBox, NamePlaceholder);
            UpdatePlaceholder(TypeTextBox, TypePlaceholder);
            UpdatePlaceholder(BreedTextBox, BreedPlaceholder);
            UpdatePlaceholder(AgeTextBox, AgePlaceholder);
            UpdatePlaceholder(HealthStatusTextBox, HealthStatusPlaceholder);
            UpdatePlaceholder(DescriptionTextBox, DescriptionPlaceholder);
        }

        private void UpdatePlaceholder(TextBox textBox, TextBlock placeholder)
        {
            placeholder.Visibility = string.IsNullOrEmpty(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock placeholder = null;

            switch (textBox.Name)
            {
                case "NameTextBox":
                    placeholder = NamePlaceholder;
                    break;
                case "TypeTextBox":
                    placeholder = TypePlaceholder;
                    break;
                case "BreedTextBox":
                    placeholder = BreedPlaceholder;
                    break;
                case "AgeTextBox":
                    placeholder = AgePlaceholder;
                    break;
                case "HealthStatusTextBox":
                    placeholder = HealthStatusPlaceholder;
                    break;
                case "DescriptionTextBox":
                    placeholder = DescriptionPlaceholder;
                    break;
            }

            if (placeholder != null)
            {
                UpdatePlaceholder(textBox, placeholder);
            }
        }

        private void SaveAnimal_Click(object sender, RoutedEventArgs e)
        {
            var animal = new Animal
            {
                Id = animals.Count > 0 ? animals[animals.Count - 1].Id + 1 : 1,
                Name = NameTextBox.Text,
                Type = TypeTextBox.Text,
                Breed = BreedTextBox.Text,
                Age = AgeTextBox.Text,
                HealthStatus = HealthStatusTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            animals.Add(animal);
            DatabaseHelper.SaveAnimals(animals);

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
