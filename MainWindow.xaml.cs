using System.Windows;

namespace Система_догляду_за_тваринами
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterAnimal_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterAnimal();
            registerWindow.Show();
            this.Close();
        }

        private void ShowAnimalList_Click(object sender, RoutedEventArgs e)
        {
            var animalListWindow = new AnimalList();
            animalListWindow.Show();
            this.Close();
        }

        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
