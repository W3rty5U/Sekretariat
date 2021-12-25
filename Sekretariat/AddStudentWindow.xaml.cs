using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        BitmapImage bmp;
        public AddStudentWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(textboxImie.Text, @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane imię!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!textboxDrugieImie.Text.Equals("") && !Regex.IsMatch(textboxDrugieImie.Text, @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$"))
            {
                MessageBox.Show(this, "Błędnie podane drugie imię!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxNazwisko.Text, @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+(-[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+)?$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane nazwisko!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxPesel.Text, @"^[0-9]{11}$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podany numer PESEL!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (comboboxPlec.SelectedItem == null)
            {
                MessageBox.Show(this, "Nie podano płci!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxImieMatki.Text, @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane imię matki!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxImieOjca.Text, @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane imię ojca!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxKlasa.Text, @"^\d\w+$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podana klasa!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (textboxGrupy.Text.Contains(";"))
            {
                MessageBox.Show(this, "Niedozwolony znak (;) w grupach!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string
                imie = textboxImie.Text,
                drugieImie = textboxDrugieImie.Text,
                nazwisko = textboxNazwisko.Text,
                nazwiskoRodowe = textboxNazwiskoRodowe.Text,
                pesel = textboxPesel.Text,
                zdjecie = imie + System.DateTime.Now.ToString("ddMMyyyyHHmmss"),
                plec = comboboxPlec.SelectedItem.ToString(),
                imieMatki = textboxImieMatki.Text,
                imieOjca = textboxImieOjca.Text,
                klasa = textboxKlasa.Text,
                grupy = textboxGrupy.Text;

            MainWindow.Uczen uczen = new MainWindow.Uczen();
            DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void choosePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obrazy (*.png;*.jpeg)|*.png;*.jpeg|Wszystkie pliki (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri uri = new Uri(openFileDialog.FileName);
                bmp = new BitmapImage(uri);
                Photo.Source = bmp;
            }
        }

    }
}
