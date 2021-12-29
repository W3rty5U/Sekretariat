using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Uczen> uczniowie;
        List<Nauczyciel> nauczyciele;
        List<Pracownik> pracownicy;
        public MainWindow()
        {
            InitializeComponent();

            uczniowie = new List<Uczen>();
            nauczyciele = new List<Nauczyciel>();
            pracownicy = new List<Pracownik>();

            // Will be calling some loading functions soon™

            dgUczniowie.ItemsSource = uczniowie;
            dgNauczyciele.ItemsSource = nauczyciele;
            dgPracownicy.ItemsSource = pracownicy;
        }
        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow window = new AddStudentWindow();
            window.Owner = this;
            if (window.ShowDialog() == true)
            {
                string
                    imie = window.textboxImie.Text,
                    drugieImie = window.textboxDrugieImie.Text,
                    nazwisko = window.textboxNazwisko.Text,
                    nazwiskoRodowe = window.textboxNazwiskoRodowe.Text,
                    pesel = window.textboxPesel.Text,
                    zdjecie = imie + DateTime.Now.ToString("ddMMyyyyHHmmss"),
                    plec = window.comboboxPlec.SelectedItem.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    klasa = window.textboxKlasa.Text,
                    grupy = window.textboxGrupy.Text;

                DateTime dataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;

                saveImage(zdjecie, window.bmp);

                uczniowie.Add(new Uczen() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec.Equals("Kobieta") ? 'K' : 'M', ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = dataUrodzenia, Klasa = klasa, Grupy = grupy });
                dgUczniowie.Items.Refresh();
                saveData();
            }
        }

        private void addTeacher_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherWindow window = new AddTeacherWindow();
            window.Owner = this;
            if (window.ShowDialog() == true)
            {
                string
                    imie = window.textboxImie.Text,
                    drugieImie = window.textboxDrugieImie.Text,
                    nazwisko = window.textboxNazwisko.Text,
                    nazwiskoRodowe = window.textboxNazwiskoRodowe.Text,
                    pesel = window.textboxPesel.Text,
                    zdjecie = imie + DateTime.Now.ToString("ddMMyyyyHHmmss"),
                    plec = window.comboboxPlec.SelectedItem.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    wychowawstwo = window.textboxWychowawstwo.Text,
                    przedmioty = window.textboxPrzedmioty.Text,
                    nauczanie = window.textboxNauczanie.Text;

                DateTime dataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                DateTime dataZatrudnienia = (DateTime)window.datepickerDataZatrudnienia.SelectedDate;

                saveImage(zdjecie, window.bmp);

                nauczyciele.Add(new Nauczyciel() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec.Equals("Kobieta") ? 'K' : 'M', ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = dataUrodzenia, Wychowawstwo = wychowawstwo, Przedmioty = przedmioty, Nauczanie = nauczanie, DataZatrudnienia = dataZatrudnienia });
                dgNauczyciele.Items.Refresh();
                saveData();
            }
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {
            addStaffWindow window = new addStaffWindow();
            window.Owner = this;
            if (window.ShowDialog() == true)
            {
                string
                    imie = window.textboxImie.Text,
                    drugieImie = window.textboxDrugieImie.Text,
                    nazwisko = window.textboxNazwisko.Text,
                    nazwiskoRodowe = window.textboxNazwiskoRodowe.Text,
                    pesel = window.textboxPesel.Text,
                    zdjecie = imie + DateTime.Now.ToString("ddMMyyyyHHmmss"),
                    plec = window.comboboxPlec.SelectedItem.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    etat = window.textboxEtat.Text,
                    opis = window.textboxOpis.Text;

                DateTime dataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                DateTime dataZatrudnienia = (DateTime)window.datepickerDataZatrudnienia.SelectedDate;

                saveImage(zdjecie, window.bmp);

                pracownicy.Add(new Pracownik() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec.Equals("Kobieta") ? 'K' : 'M', ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = dataUrodzenia, Etat = etat, Opis = opis, DataZatrudnienia = dataZatrudnienia });
                dgPracownicy.Items.Refresh();
                saveData();
            }
        }
        
        private void saveImage(string name, BitmapImage image)
        {
            if (!Directory.Exists(@".\img"))
                Directory.CreateDirectory(@".\img");

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            FileStream fileStream = new FileStream($@".\img\{name}.png", FileMode.CreateNew);
            encoder.Save(fileStream);
            fileStream.Close();
        }

        private void saveData()
        {
            string data = "";

            foreach (Uczen u in uczniowie) 
                data += $"student;{u.Imie};{u.DrugieImie};{u.Nazwisko};{u.NazwiskoRodowe};{u.Pesel};{u.Zdjecie};{u.Plec};{u.ImieMatki};{u.ImieOjca};{u.DataUrodzenia.ToShortDateString()};{u.Klasa};{u.Grupy}\n";

            foreach (Nauczyciel n in nauczyciele)
                data += $"teacher;{n.Imie};{n.DrugieImie};{n.Nazwisko};{n.NazwiskoRodowe};{n.Pesel};{n.Zdjecie};{n.Plec};{n.ImieMatki};{n.ImieOjca};{n.DataUrodzenia.ToShortDateString()};{n.Wychowawstwo};{n.Przedmioty};{n.Nauczanie};{n.DataZatrudnienia.ToShortDateString()}\n";

            foreach (Pracownik p in pracownicy)
                data += $"staff;{p.Imie};{p.DrugieImie};{p.Nazwisko};{p.NazwiskoRodowe};{p.Pesel};{p.Zdjecie};{p.Plec};{p.ImieMatki};{p.ImieOjca};{p.DataUrodzenia.ToShortDateString()};{p.Etat};{p.Opis};{p.DataZatrudnienia.ToShortDateString()}\n";

            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}data.txt", data);
        }

        public class Osoba
        {
            public string Imie { get; set; }
            public string DrugieImie { get; set; }
            public string Nazwisko { get; set; }
            public string NazwiskoRodowe { get; set; }
            public string Pesel { get; set; }
            public string Zdjecie { get; set; }
            public char Plec { get; set; }
            public string ImieMatki { get; set; }
            public string ImieOjca { get; set; }
            public DateTime DataUrodzenia { get; set; }
        }

        public class Uczen : Osoba
        {
            public string Klasa { get; set; }
            public string Grupy { get; set; }
        }

        public class Nauczyciel : Osoba
        {
            public string Wychowawstwo { get; set; }
            public string Przedmioty { get; set; }
            public string Nauczanie { get; set; }
            public DateTime DataZatrudnienia { get; set; }
        }

        public class Pracownik : Osoba
        {
            public string Etat { get; set; }
            public string Opis { get; set; }
            public DateTime DataZatrudnienia { get; set; }
        }
    }

    public class StringToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriString = value as string;
            uriString = $@"{AppDomain.CurrentDomain.BaseDirectory}img\{uriString}.png";
            return new BitmapImage(new Uri(uriString));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
