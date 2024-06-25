using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Система_догляду_за_тваринами
{
    public partial class AnimalList : Window
    {
        private List<Animal> animals;

        public AnimalList()
        {
            InitializeComponent();
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            animals = DatabaseHelper.LoadAnimals();
            AnimalsListView.ItemsSource = animals;
        }

        private void SearchAnimal_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchAnimal();
            searchWindow.Show();
            this.Close();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AnimalsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAnimal = (Animal)AnimalsListView.SelectedItem;
            if (selectedAnimal != null)
            {
                var animalDetailsWindow = new AnimalDetails(selectedAnimal);
                animalDetailsWindow.Show();
                this.Close();
            }
        }
    }
}
