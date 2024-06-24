using System.Windows;

namespace Система_догляду_за_тваринами
{
    public partial class AnimalList : Window
    {
        public AnimalList()
        {
            InitializeComponent();
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            // Загружаем список животных из локальной базы данных
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
