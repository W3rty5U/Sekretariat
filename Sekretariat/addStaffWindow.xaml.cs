using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for addStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        public BitmapImage bmp;

        public AddStaffWindow()
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
            if (!Regex.IsMatch(textboxDrugieImie.Text, @"^([A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+)?$"))
            {
                MessageBox.Show(this, "Błędnie podane drugie imię!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxNazwisko.Text, @"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+(-[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+)?$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podane nazwisko!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxNazwiskoRodowe.Text, @"^([A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+(-[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+)?)?$"))
            {
                MessageBox.Show(this, "Błędnie podane nazwisko rodowe!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(textboxPesel.Text, @"^[0-9]{11}$"))
            {
                MessageBox.Show(this, "Brak lub błędnie podany numer PESEL!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Photo.Source == null)
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
            if (textboxEtat.Text.Contains(";"))
            {
                MessageBox.Show(this, "Niedozwolony znak (;) w etacie!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (textboxOpis.Text.Contains(";"))
            {
                MessageBox.Show(this, "Niedozwolony znak (;) w opisie!", "Nieprawidłowe dane", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            openFileDialog.Filter = "Obrazy (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Wszystkie pliki (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri uri = new Uri(openFileDialog.FileName);
                bmp = new BitmapImage(uri);
                Photo.Source = bmp;
            }
        }
    }
}
