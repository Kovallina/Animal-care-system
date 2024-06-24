using System.Collections.Generic;
using System.Windows;

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
    }
}
