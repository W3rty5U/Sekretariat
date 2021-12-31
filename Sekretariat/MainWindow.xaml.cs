using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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

            loadData();

            dgUczniowie.ItemsSource = uczniowie;
            dgNauczyciele.ItemsSource = nauczyciele;
            dgPracownicy.ItemsSource = pracownicy;

            clearSearchBtn.IsEnabled = false;
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
                    plec = ((ComboBoxItem)window.comboboxPlec.SelectedItem).Content.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    klasa = window.textboxKlasa.Text,
                    grupy = window.textboxGrupy.Text;

                DateTime dataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;

                saveImage(zdjecie, window.bmp);

                uczniowie.Add(new Uczen() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec[0], ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = dataUrodzenia, Klasa = klasa, Grupy = grupy });
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
                    plec = ((ComboBoxItem)window.comboboxPlec.SelectedItem).Content.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    wychowawstwo = window.textboxWychowawstwo.Text,
                    przedmioty = window.textboxPrzedmioty.Text,
                    nauczanie = window.textboxNauczanie.Text;

                DateTime dataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                DateTime dataZatrudnienia = (DateTime)window.datepickerDataZatrudnienia.SelectedDate;

                saveImage(zdjecie, window.bmp);

                nauczyciele.Add(new Nauczyciel() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec[0], ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = dataUrodzenia, Wychowawstwo = wychowawstwo, Przedmioty = przedmioty, Nauczanie = nauczanie, DataZatrudnienia = dataZatrudnienia });
                dgNauczyciele.Items.Refresh();
                saveData();
            }
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWindow window = new AddStaffWindow();
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
                    plec = ((ComboBoxItem)window.comboboxPlec.SelectedItem).Content.ToString(),
                    imieMatki = window.textboxImieMatki.Text,
                    imieOjca = window.textboxImieOjca.Text,
                    etat = window.textboxEtat.Text,
                    opis = window.textboxOpis.Text;

                DateTime dataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                DateTime dataZatrudnienia = (DateTime)window.datepickerDataZatrudnienia.SelectedDate;

                saveImage(zdjecie, window.bmp);

                pracownicy.Add(new Pracownik() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec[0], ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = dataUrodzenia, Etat = etat, Opis = opis, DataZatrudnienia = dataZatrudnienia });
                dgPracownicy.Items.Refresh();
                saveData();
            }
        }

        private void editStudent_Click(object sender, RoutedEventArgs e)
        {
            Uczen uczen = (Uczen)((Button)e.Source).DataContext;
            int index = uczniowie.IndexOf(uczen);

            AddStudentWindow window = new AddStudentWindow();
            window.Owner = this;
            window.textboxImie.Text = uczniowie[index].Imie;
            window.textboxDrugieImie.Text = uczniowie[index].DrugieImie;
            window.textboxNazwisko.Text = uczniowie[index].Nazwisko;
            window.textboxNazwiskoRodowe.Text = uczniowie[index].NazwiskoRodowe;
            window.textboxPesel.Text = uczniowie[index].Pesel;
            window.Photo.Source = new BitmapImage(new Uri($@"{AppDomain.CurrentDomain.BaseDirectory}img\{uczniowie[index].Zdjecie}.png"));
            window.comboboxPlec.SelectedItem = uczniowie[index].Plec == 'K' ? window.comboboxPlec.Items[0] : window.comboboxPlec.Items[1];
            window.textboxImieMatki.Text = uczniowie[index].ImieMatki;
            window.textboxImieOjca.Text = uczniowie[index].ImieOjca;
            window.datepickerDataUrodzenia.SelectedDate = uczniowie[index].DataUrodzenia;
            window.textboxKlasa.Text = uczniowie[index].Klasa;
            window.textboxGrupy.Text = uczniowie[index].Grupy;

            if (window.ShowDialog() == true)
            {
                uczniowie[index].Imie = window.textboxImie.Text;
                uczniowie[index].DrugieImie = window.textboxDrugieImie.Text;
                uczniowie[index].Nazwisko = window.textboxNazwisko.Text;
                uczniowie[index].NazwiskoRodowe = window.textboxNazwiskoRodowe.Text;
                uczniowie[index].Pesel = window.textboxPesel.Text;
                uczniowie[index].Plec = ((ComboBoxItem)window.comboboxPlec.SelectedItem).Content.ToString()[0];
                uczniowie[index].ImieMatki = window.textboxImieMatki.Text;
                uczniowie[index].ImieOjca = window.textboxImieOjca.Text;
                uczniowie[index].DataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                uczniowie[index].Klasa = window.textboxKlasa.Text;
                uczniowie[index].Grupy = window.textboxGrupy.Text;

                if (window.bmp != null)
                {
                    uczniowie[index].Zdjecie = uczniowie[index].Imie + DateTime.Now.ToString("ddMMyyyyHHmmss");
                    saveImage(uczniowie[index].Zdjecie, window.bmp);
                }

                dgUczniowie.Items.Refresh();
                saveData();
            }
        }

        private void editTeacher_Click(object sender, RoutedEventArgs e)
        {
            Nauczyciel nauczyciel = (Nauczyciel)((Button)e.Source).DataContext;
            int index = nauczyciele.IndexOf(nauczyciel);

            AddTeacherWindow window = new AddTeacherWindow();
            window.Owner = this;
            window.textboxImie.Text = nauczyciele[index].Imie;
            window.textboxDrugieImie.Text = nauczyciele[index].DrugieImie;
            window.textboxNazwisko.Text = nauczyciele[index].Nazwisko;
            window.textboxNazwiskoRodowe.Text = nauczyciele[index].NazwiskoRodowe;
            window.textboxPesel.Text = nauczyciele[index].Pesel;
            window.Photo.Source = new BitmapImage(new Uri($@"{AppDomain.CurrentDomain.BaseDirectory}img\{nauczyciele[index].Zdjecie}.png"));
            window.comboboxPlec.SelectedItem = nauczyciele[index].Plec == 'K' ? window.comboboxPlec.Items[0] : window.comboboxPlec.Items[1];
            window.textboxImieMatki.Text = nauczyciele[index].ImieMatki;
            window.textboxImieOjca.Text = nauczyciele[index].ImieOjca;
            window.datepickerDataUrodzenia.SelectedDate = nauczyciele[index].DataUrodzenia;
            window.textboxWychowawstwo.Text = nauczyciele[index].Wychowawstwo;
            window.textboxPrzedmioty.Text = nauczyciele[index].Przedmioty;
            window.textboxNauczanie.Text = nauczyciele[index].Nauczanie;
            window.datepickerDataZatrudnienia.SelectedDate = nauczyciele[index].DataZatrudnienia;

            if (window.ShowDialog() == true)
            {
                nauczyciele[index].Imie = window.textboxImie.Text;
                nauczyciele[index].DrugieImie = window.textboxDrugieImie.Text;
                nauczyciele[index].Nazwisko = window.textboxNazwisko.Text;
                nauczyciele[index].NazwiskoRodowe = window.textboxNazwiskoRodowe.Text;
                nauczyciele[index].Pesel = window.textboxPesel.Text;
                nauczyciele[index].Plec = ((ComboBoxItem)window.comboboxPlec.SelectedItem).Content.ToString()[0];
                nauczyciele[index].ImieMatki = window.textboxImieMatki.Text;
                nauczyciele[index].ImieOjca = window.textboxImieOjca.Text;
                nauczyciele[index].DataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                nauczyciele[index].Wychowawstwo = window.textboxWychowawstwo.Text;
                nauczyciele[index].Przedmioty = window.textboxPrzedmioty.Text;
                nauczyciele[index].Nauczanie = window.textboxNauczanie.Text;
                nauczyciele[index].DataZatrudnienia = (DateTime)window.datepickerDataZatrudnienia.SelectedDate;

                if (window.bmp != null)
                {
                    nauczyciele[index].Zdjecie = nauczyciele[index].Imie + DateTime.Now.ToString("ddMMyyyyHHmmss");
                    saveImage(nauczyciele[index].Zdjecie, window.bmp);
                }

                dgNauczyciele.Items.Refresh();
                saveData();
            }
        }

        private void editStaff_Click(object sender, RoutedEventArgs e)
        {
            Pracownik pracownik = (Pracownik)((Button)e.Source).DataContext;
            int index = pracownicy.IndexOf(pracownik);

            AddStaffWindow window = new AddStaffWindow();
            window.Owner = this;
            window.textboxImie.Text = pracownicy[index].Imie;
            window.textboxDrugieImie.Text = pracownicy[index].DrugieImie;
            window.textboxNazwisko.Text = pracownicy[index].Nazwisko;
            window.textboxNazwiskoRodowe.Text = pracownicy[index].NazwiskoRodowe;
            window.textboxPesel.Text = pracownicy[index].Pesel;
            window.Photo.Source = new BitmapImage(new Uri($@"{AppDomain.CurrentDomain.BaseDirectory}img\{pracownicy[index].Zdjecie}.png"));
            window.comboboxPlec.SelectedItem = pracownicy[index].Plec == 'K' ? window.comboboxPlec.Items[0] : window.comboboxPlec.Items[1];
            window.textboxImieMatki.Text = pracownicy[index].ImieMatki;
            window.textboxImieOjca.Text = pracownicy[index].ImieOjca;
            window.datepickerDataUrodzenia.SelectedDate = pracownicy[index].DataUrodzenia;
            window.textboxEtat.Text = pracownicy[index].Etat;
            window.textboxOpis.Text = pracownicy[index].Opis;
            window.datepickerDataZatrudnienia.SelectedDate = pracownicy[index].DataZatrudnienia;


            if (window.ShowDialog() == true)
            {
                pracownicy[index].Imie = window.textboxImie.Text;
                pracownicy[index].DrugieImie = window.textboxDrugieImie.Text;
                pracownicy[index].Nazwisko = window.textboxNazwisko.Text;
                pracownicy[index].NazwiskoRodowe = window.textboxNazwiskoRodowe.Text;
                pracownicy[index].Pesel = window.textboxPesel.Text;
                pracownicy[index].Plec = ((ComboBoxItem)window.comboboxPlec.SelectedItem).Content.ToString()[0];
                pracownicy[index].ImieMatki = window.textboxImieMatki.Text;
                pracownicy[index].ImieOjca = window.textboxImieOjca.Text;
                pracownicy[index].DataUrodzenia = (DateTime)window.datepickerDataUrodzenia.SelectedDate;
                pracownicy[index].Etat = window.textboxEtat.Text;
                pracownicy[index].Opis = window.textboxOpis.Text;
                pracownicy[index].DataZatrudnienia = (DateTime)window.datepickerDataZatrudnienia.SelectedDate;

                if (window.bmp != null)
                {
                    pracownicy[index].Zdjecie = pracownicy[index].Imie + DateTime.Now.ToString("ddMMyyyyHHmmss");
                    saveImage(pracownicy[index].Zdjecie, window.bmp);
                }

                dgPracownicy.Items.Refresh();
                saveData();
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();

            searchWindow.cbSearchIn.SelectedIndex = tabControl.SelectedIndex;

            if (searchWindow.ShowDialog() == true)
            {
                string searchPhrase = searchWindow.tbSearchFor.Text;
                if (searchWindow.cbSearchIn.SelectedIndex == 0)
                {
                    List<Uczen> wynikiUczniowie = new List<Uczen>();
                    foreach (Uczen u in uczniowie)
                    {
                        switch (searchWindow.cbSearchFor.SelectedIndex)
                        {
                            case 0:
                                if (u.Imie.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 1:
                                if (u.DrugieImie.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 2:
                                if (u.Nazwisko.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 3:
                                if (u.NazwiskoRodowe.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 4:
                                if (u.Pesel.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 5:
                                if (u.Plec == searchPhrase.ToUpper()[0])
                                    wynikiUczniowie.Add(u);
                                break;
                            case 6:
                                if (u.ImieMatki.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 7:
                                if (u.ImieOjca.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 8:
                                if (u.DataUrodzenia.ToShortDateString().Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 9:
                                if (u.Klasa.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                            case 10:
                                if (u.Grupy.Contains(searchPhrase))
                                    wynikiUczniowie.Add(u);
                                break;
                        }
                    }
                    dgUczniowie.ItemsSource = wynikiUczniowie;
                    dgUczniowie.Items.Refresh();
                }
                else if (searchWindow.cbSearchIn.SelectedIndex == 1)
                {
                    List<Nauczyciel> wynikiNauczyciele = new List<Nauczyciel>();
                    foreach (Nauczyciel n in nauczyciele)
                    {
                        switch (searchWindow.cbSearchFor.SelectedIndex)
                        {
                            case 0:
                                if (n.Imie.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 1:
                                if (n.DrugieImie.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 2:
                                if (n.Nazwisko.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 3:
                                if (n.NazwiskoRodowe.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 4:
                                if (n.Pesel.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 5:
                                if (n.Plec == searchPhrase.ToUpper()[0])
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 6:
                                if (n.ImieMatki.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 7:
                                if (n.ImieOjca.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 8:
                                if (n.DataUrodzenia.ToShortDateString().Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 9:
                                if (n.Wychowawstwo.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 10:
                                if (n.Przedmioty.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 11:
                                if (n.Nauczanie.Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                            case 12:
                                if (n.DataZatrudnienia.ToShortDateString().Contains(searchPhrase))
                                    wynikiNauczyciele.Add(n);
                                break;
                        }
                    }
                    dgNauczyciele.ItemsSource = wynikiNauczyciele;
                    dgNauczyciele.Items.Refresh();
                }
                else if (searchWindow.cbSearchIn.SelectedIndex == 2)
                {
                    List<Pracownik> wynikiPracownicy = new List<Pracownik>();
                    foreach (Pracownik p in pracownicy)
                    {
                        switch (searchWindow.cbSearchFor.SelectedIndex)
                        {
                            case 0:
                                if (p.Imie.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 1:
                                if (p.DrugieImie.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 2:
                                if (p.Nazwisko.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 3:
                                if (p.NazwiskoRodowe.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 4:
                                if (p.Pesel.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 5:
                                if (p.Plec == searchPhrase.ToUpper()[0])
                                    wynikiPracownicy.Add(p);
                                break;
                            case 6:
                                if (p.ImieMatki.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 7:
                                if (p.ImieOjca.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 8:
                                if (p.DataUrodzenia.ToShortDateString().Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 9:
                                if (p.Etat.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 10:
                                if (p.Opis.Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                            case 11:
                                if (p.DataZatrudnienia.ToShortDateString().Contains(searchPhrase))
                                    wynikiPracownicy.Add(p);
                                break;
                        }
                    }
                    dgPracownicy.ItemsSource = wynikiPracownicy;
                    dgPracownicy.Items.Refresh();
                }
                clearSearchBtn.IsEnabled = true;
            }
        }

        private void clearSearch_Click(object sender, RoutedEventArgs e)
        {
            dgUczniowie.ItemsSource = uczniowie;
            dgNauczyciele.ItemsSource = nauczyciele;
            dgPracownicy.ItemsSource = pracownicy;

            dgUczniowie.Items.Refresh();
            dgNauczyciele.Items.Refresh();
            dgPracownicy.Items.Refresh();
        }

        private void saveResults_Click(object sender, RoutedEventArgs e)
        {
            string data = "";

            if (tabControl.SelectedIndex == 0)
                foreach (Uczen u in dgUczniowie.ItemsSource)
                    data += $"student;{u.Imie};{u.DrugieImie};{u.Nazwisko};{u.NazwiskoRodowe};{u.Pesel};{u.Plec};{u.ImieMatki};{u.ImieOjca};{u.DataUrodzenia.ToShortDateString()};{u.Klasa};{u.Grupy}\n";

            else if (tabControl.SelectedIndex == 1)
                foreach (Nauczyciel n in dgNauczyciele.ItemsSource)
                    data += $"teacher;{n.Imie};{n.DrugieImie};{n.Nazwisko};{n.NazwiskoRodowe};{n.Pesel};{n.Plec};{n.ImieMatki};{n.ImieOjca};{n.DataUrodzenia.ToShortDateString()};{n.Wychowawstwo};{n.Przedmioty};{n.Nauczanie};{n.DataZatrudnienia.ToShortDateString()}\n";

            else if (tabControl.SelectedIndex == 2)
                foreach (Pracownik p in dgPracownicy.ItemsSource)
                    data += $"staff;{p.Imie};{p.DrugieImie};{p.Nazwisko};{p.NazwiskoRodowe};{p.Pesel};{p.Plec};{p.ImieMatki};{p.ImieOjca};{p.DataUrodzenia.ToShortDateString()};{p.Etat};{p.Opis};{p.DataZatrudnienia.ToShortDateString()}\n";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.FileName = $"Raport{DateTime.Now:ddMMyyyyHHmmss}.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, data);
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

        private void loadData()
        {
            if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}data.txt"))
                return;

            List<Uczen> dodaniUczniowie = new List<Uczen>();
            List<Nauczyciel> dodaniNauczyciele = new List<Nauczyciel>();
            List<Pracownik> dodaniPracownicy = new List<Pracownik>();

            foreach (string line in File.ReadAllLines($"{AppDomain.CurrentDomain.BaseDirectory}data.txt"))
            {
                string[] data = line.Split(';');

                string
                    imie = data[1],
                    drugieImie = data[2],
                    nazwisko = data[3],
                    nazwiskoRodowe = data[4],
                    pesel = data[5],
                    zdjecie = data[6],
                    plec = data[7],
                    imieMatki = data[8],
                    imieOjca = data[9],
                    dataUrodzenia = data[10];

                if (data[0].Equals("student"))
                {
                    string
                        klasa = data[11],
                        grupy = data[12];

                    dodaniUczniowie.Add(new Uczen() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec[0], ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = DateTime.Parse(dataUrodzenia), Klasa = klasa, Grupy = grupy });
                }
                else if (data[0].Equals("teacher"))
                {
                    string
                        wychowawstwo = data[11],
                        przedmioty = data[12],
                        nauczanie = data[13],
                        dataZatrudnienia = data[14];

                    dodaniNauczyciele.Add(new Nauczyciel() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec[0], ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = DateTime.Parse(dataUrodzenia), Wychowawstwo = wychowawstwo, Przedmioty = przedmioty, Nauczanie = nauczanie, DataZatrudnienia = DateTime.Parse(dataZatrudnienia) });
                }
                else if (data[0].Equals("staff"))
                {
                    string
                        etat = data[11],
                        opis = data[12],
                        dataZatrudnienia = data[13];

                    dodaniPracownicy.Add(new Pracownik() { Imie = imie, DrugieImie = drugieImie, Nazwisko = nazwisko, NazwiskoRodowe = nazwiskoRodowe, Pesel = pesel, Zdjecie = zdjecie, Plec = plec[0], ImieMatki = imieMatki, ImieOjca = imieOjca, DataUrodzenia = DateTime.Parse(dataUrodzenia), Etat = etat, Opis = opis, DataZatrudnienia = DateTime.Parse(dataZatrudnienia) });
                }
                else
                {
                    MessageBox.Show(this, "Błąd odczytu danych!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            uczniowie.AddRange(dodaniUczniowie);
            nauczyciele.AddRange(dodaniNauczyciele);
            pracownicy.AddRange(dodaniPracownicy);
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

    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToShortDateString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
