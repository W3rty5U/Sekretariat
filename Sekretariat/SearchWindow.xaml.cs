using System.Windows;
using System.Windows.Controls;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbSearchIn.SelectedIndex == -1 || cbSearchFor.SelectedIndex == -1 || tbSearchFor.Text.Equals(""))
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
                return;
            }
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void cbSearchIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSearchIn.SelectedIndex == 0)
            {
                cbSearchFor.ItemsSource = new ComboBoxItem[] {
                    new ComboBoxItem() { Content = "Imie" },
                    new ComboBoxItem() { Content = "Drugie imie" },
                    new ComboBoxItem() { Content = "Nazwisko" },
                    new ComboBoxItem() { Content = "Nazwisko panieńskie" },
                    new ComboBoxItem() { Content = "Pesel" },
                    new ComboBoxItem() { Content = "Płeć" },
                    new ComboBoxItem() { Content = "Imie matki" },
                    new ComboBoxItem() { Content = "Imie ojca" },
                    new ComboBoxItem() { Content = "Data urodzenia" },
                    new ComboBoxItem() { Content = "Klasa" },
                    new ComboBoxItem() { Content = "Grupy" }
                };
            }
            else if (cbSearchIn.SelectedIndex == 1)
            {
                cbSearchFor.ItemsSource = new ComboBoxItem[] {
                    new ComboBoxItem() { Content = "Imie" },
                    new ComboBoxItem() { Content = "Drugie imie" },
                    new ComboBoxItem() { Content = "Nazwisko" },
                    new ComboBoxItem() { Content = "Nazwisko panieńskie" },
                    new ComboBoxItem() { Content = "Pesel" },
                    new ComboBoxItem() { Content = "Płeć" },
                    new ComboBoxItem() { Content = "Imie matki" },
                    new ComboBoxItem() { Content = "Imie ojca" },
                    new ComboBoxItem() { Content = "Data urodzenia" },
                    new ComboBoxItem() { Content = "Wychowawstwo" },
                    new ComboBoxItem() { Content = "Przedmioty" },
                    new ComboBoxItem() { Content = "Nauczanie" },
                    new ComboBoxItem() { Content = "Data zatrudnienia" }
                };
            }
            else if (cbSearchIn.SelectedIndex == 2)
            {
                cbSearchFor.ItemsSource = new ComboBoxItem[] {
                    new ComboBoxItem() { Content = "Imie" },
                    new ComboBoxItem() { Content = "Drugie imie" },
                    new ComboBoxItem() { Content = "Nazwisko" },
                    new ComboBoxItem() { Content = "Nazwisko panieńskie" },
                    new ComboBoxItem() { Content = "Pesel" },
                    new ComboBoxItem() { Content = "Płeć" },
                    new ComboBoxItem() { Content = "Imie matki" },
                    new ComboBoxItem() { Content = "Imie ojca" },
                    new ComboBoxItem() { Content = "Data urodzenia" },
                    new ComboBoxItem() { Content = "Etat" },
                    new ComboBoxItem() { Content = "Opis" },
                    new ComboBoxItem() { Content = "Data zatrudnienia" }
                };
            }
        }
    }
}
