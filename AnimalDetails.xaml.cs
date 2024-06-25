using System.Windows;

namespace Система_догляду_за_тваринами
{
    public partial class AnimalDetails : Window
    {
        private Animal animal;

        public AnimalDetails(Animal animal)
        {
            InitializeComponent();
            this.animal = animal;
            LoadAnimalDetails();
        }

        private void LoadAnimalDetails()
        {
            NameTextBox.Text = animal.Name;
            TypeTextBox.Text = animal.Type;
            BreedTextBox.Text = animal.Breed;
            AgeTextBox.Text = animal.Age;
            HealthStatusTextBox.Text = animal.HealthStatus;
            DescriptionTextBox.Text = animal.Description;
            NotesTextBox.Text = animal.Notes;
        }

        private void SaveNotes_Click(object sender, RoutedEventArgs e)
        {
            animal.Age = AgeTextBox.Text;
            animal.HealthStatus = HealthStatusTextBox.Text;
            animal.Description = DescriptionTextBox.Text;
            animal.Notes = NotesTextBox.Text;

            var animals = DatabaseHelper.LoadAnimals();
            var animalToUpdate = animals.Find(a => a.Id == animal.Id);
            if (animalToUpdate != null) 
            {
                animalToUpdate.Age = animal.Age;
                animalToUpdate.HealthStatus = animal.HealthStatus;
                animalToUpdate.Description = animal.Description;
                animalToUpdate.Notes = animal.Notes;
                DatabaseHelper.SaveAnimals(animals);
            }

            var animalListWindow = new AnimalList();
            animalListWindow.Show();
            this.Close();
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
        var result = MessageBox.Show("Ви впевнені, що хочете видалити цю тварину?", "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (result == MessageBoxResult.Yes) 
            {
             var animals = DatabaseHelper.LoadAnimals();
             var animalToDelete = animals.Find(a => a.Id == animal.Id);
             if (animalToDelete != null) 
             {
                 animals.Remove(animalToDelete);
                 DatabaseHelper.SaveAnimals(animals);
             }

             var animalListWindow = new AnimalList();
             animalListWindow.Show();
             this.Close();
            }
        }
    }
}
