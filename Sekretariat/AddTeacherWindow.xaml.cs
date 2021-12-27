using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        public BitmapImage bmp;

        public AddTeacherWindow()
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
            if (bmp == null)
            {
                MessageBox.Show(this, "Nie dodano zdjęcia!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (datepickerDataUrodzenia.ToString().Equals(""))
            {
                MessageBox.Show(this, "Nie podano daty urodzenia!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxWychowawstwo.Text, @"^\d\w+$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane wychowawstwo!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (textboxPrzedmioty.Text.Equals(""))
            {
                MessageBox.Show(this, "Nie podano nauczanych przedmiotów!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (textboxPrzedmioty.Text.Contains(";"))
            {
                MessageBox.Show(this, "Niedozwolony znak (;) w przedmiotach!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxNauczanie.Text, @"^\d\w+\ [1-9][0-9]*(,\ \d\w+\ [1-9][0-9]*)*$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane nauczanie!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (datepickerDataZatrudnienia.ToString().Equals(""))
            {
                MessageBox.Show(this, "Nie podano daty zatrudnienia!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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
