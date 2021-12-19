using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        struct Osoba
        {
            string imie;
            string drugieImie;
            string nazwisko;
            string nazwiskoPanienskie;
            string pesel;
            string zdjecie;
            char plec;
            string imieMatki;
            string imieOjca;
            DateTime dataUrodzenia;
        }

        struct Uczen
        {
            Osoba osoba;
            string klasa;
            List<string> grupy;
        }

        struct Nauczyciel
        {
            Osoba osoba;
            string wychowawstwo;
            List<string> przedmioty;
            List<Tuple<string, string>> nauczanie;
            DateTime dataZatrudnienia;
        }

        struct pracownikObslugi
        {
            Osoba osoba;
            string etat;
            string opis;
            DateTime dataZatrudnienia;
        }
    }
}
