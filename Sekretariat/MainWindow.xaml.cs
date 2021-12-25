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
            if(window.ShowDialog() == true)
            {
                string
                    imie = window.textboxImie.Text,
                    drugieImie = window.textboxDrugieImie.Text,
                    nazwisko = window.textboxNazwisko.Text,
                    nazwiskoRodowe = window.textboxNazwiskoRodowe.Text,
                    pesel = window.textboxPesel.Text,
                    zdjecie = @".\img\" + imie + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + ".png",
                    plec = window.comboboxPlec.SelectedItem.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    klasa = window.textboxKlasa.Text,
                    grupy = window.textboxGrupy.Text;

                if (!Directory.Exists(@".\img"))
                    Directory.CreateDirectory(@".\img");

                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(window.bmp));
                FileStream fileStream = new FileStream(zdjecie, FileMode.CreateNew);
                encoder.Save(fileStream);

                uczniowie.Add(new Uczen() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec.Equals("Kobieta") ? 'K' : 'M', ImieMatki = imieMatki, ImieOjca = imieOjca, Klasa = klasa, Grupy = grupy });
                dgUczniowie.ItemsSource = uczniowie;
            }
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
}
