using System.Windows;
using System.Windows.Controls;

namespace Система_догляду_за_тваринами
{
    public partial class RegisterAnimal : Window
    {
        public RegisterAnimal()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

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
                placeholder.Visibility = string.IsNullOrEmpty(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void SaveAnimal_Click(object sender, RoutedEventArgs e)
        {
            // Ваша логіка для збереження даних
        }

        private void ExitWithoutSaving_Click(object sender, RoutedEventArgs e)
        {
            // Ваша логіка для виходу без збереження даних
        }
    }
}
