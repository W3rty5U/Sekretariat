using System;
using System.Collections.Generic;
using System.Windows;

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

            uczniowie.Add(new Uczen() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), klasa = "3prT4", grupy = new List<string> { "3prT4 gr1" } });
            uczniowie.Add(new Uczen() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), klasa = "3prT4", grupy = new List<string> { "3prT4 gr1" } });
            uczniowie.Add(new Uczen() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), klasa = "3prT4", grupy = new List<string> { "3prT4 gr1" } });

            dgUczniowie.ItemsSource = uczniowie;

            nauczyciele.Add(new Nauczyciel() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), wychowawstwo = "3prT4", przedmioty = new List<string> { "Angielski", "Programowanie" }, nauczanie = new List<Tuple<string, string>> { new Tuple<string, string>("Angielski", "8:00") }, dataZatrudnienia = new DateTime(2020, 9, 1) });
            nauczyciele.Add(new Nauczyciel() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), wychowawstwo = "3prT4", przedmioty = new List<string> { "Angielski", "Programowanie" }, nauczanie = new List<Tuple<string, string>> { new Tuple<string, string>("Angielski", "8:00") }, dataZatrudnienia = new DateTime(2020, 9, 1) });
            nauczyciele.Add(new Nauczyciel() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), wychowawstwo = "3prT4", przedmioty = new List<string> { "Angielski", "Programowanie" }, nauczanie = new List<Tuple<string, string>> { new Tuple<string, string>("Angielski", "8:00") }, dataZatrudnienia = new DateTime(2020, 9, 1) });
            
            dgNauczyciele.ItemsSource = nauczyciele;

            pracownicy.Add(new Pracownik() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), etat = "1/2", opis = "Koks konserwator", dataZatrudnienia = new DateTime(2019, 3, 12) });
            pracownicy.Add(new Pracownik() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), etat = "1/2", opis = "Koks konserwator", dataZatrudnienia = new DateTime(2019, 3, 12) });
            pracownicy.Add(new Pracownik() { imie = "Andrzej", drugieImie = "", nazwisko = "Kowalski", nazwiskoPanienskie = "", pesel = "1337_H4xx0r", plec = 'M', imieMatki = "Agata", imieOjca = "Mariusz", dataUrodzenia = new DateTime(2003, 12, 1), etat = "1/2", opis = "Koks konserwator", dataZatrudnienia = new DateTime(2019, 3, 12) });
            
            dgPracownicy.ItemsSource = pracownicy;
        }

        public class Osoba
        {
            public string imie { get; set; }
            public string drugieImie { get; set; }
            public string nazwisko { get; set; }
            public string nazwiskoPanienskie { get; set; }
            public string pesel { get; set; }
            public string zdjecie { get; set; }
            public char plec { get; set; }
            public string imieMatki { get; set; }
            public string imieOjca { get; set; }
            public DateTime dataUrodzenia { get; set; }
        }

        public class Uczen : Osoba
        {
            public string klasa { get; set; }
            public List<string> grupy { get; set; }
        }

        public class Nauczyciel : Osoba
        {
            public string wychowawstwo { get; set; }
            public List<string> przedmioty { get; set; }
            public List<Tuple<string, string>> nauczanie { get; set; }
            public DateTime dataZatrudnienia { get; set; }
        }

        public class Pracownik : Osoba
        {
            public string etat { get; set; }
            public string opis { get; set; }
            public DateTime dataZatrudnienia { get; set; }
        }
    }
}
