using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

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

            uczniowie.Add(new Uczen() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Klasa = "3prT4", Grupy = "3prT4 gr1" });
            uczniowie.Add(new Uczen() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Klasa = "3prT4", Grupy = "3prT4 gr1" });
            uczniowie.Add(new Uczen() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Klasa = "3prT4", Grupy = "3prT4 gr1" });

            dgUczniowie.ItemsSource = uczniowie;

            nauczyciele.Add(new Nauczyciel() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Wychowawstwo = "3prT4", Przedmioty = "Angielski, Programowanie", Nauczanie = "Angielski, 8:00", DataZatrudnienia = new DateTime(2020, 9, 1) });
            nauczyciele.Add(new Nauczyciel() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Wychowawstwo = "3prT4", Przedmioty = "Angielski, Programowanie", Nauczanie = "Angielski, 8:00", DataZatrudnienia = new DateTime(2020, 9, 1) });
            nauczyciele.Add(new Nauczyciel() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Wychowawstwo = "3prT4", Przedmioty = "Angielski, Programowanie", Nauczanie = "Angielski, 8:00", DataZatrudnienia = new DateTime(2020, 9, 1) });
            
            dgNauczyciele.ItemsSource = nauczyciele;

            pracownicy.Add(new Pracownik() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Etat = "1/2", Opis = "Koks konserwator", DataZatrudnienia = new DateTime(2019, 3, 12) });
            pracownicy.Add(new Pracownik() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Etat = "1/2", Opis = "Koks konserwator", DataZatrudnienia = new DateTime(2019, 3, 12) });
            pracownicy.Add(new Pracownik() { Imie = "Andrzej", DrugieImie = "", Nazwisko = "Kowalski", NazwiskoPanienskie = "", Pesel = "1337_H4xx0r", Plec = 'M', ImieMatki = "Agata", ImieOjca = "Mariusz", DataUrodzenia = new DateTime(2003, 12, 1), Etat = "1/2", Opis = "Koks konserwator", DataZatrudnienia = new DateTime(2019, 3, 12) });

            dgPracownicy.ItemsSource = pracownicy;
        }

        public class Osoba
        {
            public string Imie { get; set; }
            public string DrugieImie { get; set; }
            public string Nazwisko { get; set; }
            public string NazwiskoPanienskie { get; set; }
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
