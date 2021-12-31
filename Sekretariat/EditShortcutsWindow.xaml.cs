using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sekretariat
{
    /// <summary>
    /// Interaction logic for EditShortcutsWindow.xaml
    /// </summary>
    public partial class EditShortcutsWindow : Window
    {
        public int[] keys;

        public EditShortcutsWindow()
        {
            InitializeComponent();

            keys = new int[6];
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(((int)e.Key >= 34 && (int)e.Key <= 69) || ((int)e.Key >= 74 && (int)e.Key <= 83) || ((int)e.Key >= 90 && (int)e.Key <= 113)))
                return;

            TextBox textBox = (TextBox)sender;
            textBox.Text = e.Key.ToString();

            if (textBox.Name.Equals("tb1"))
                keys[0] = (int)e.Key;
            else if (textBox.Name.Equals("tb2"))
                keys[1] = (int)e.Key;
            else if (textBox.Name.Equals("tb3"))
                keys[2] = (int)e.Key;
            else if (textBox.Name.Equals("tb4"))
                keys[3] = (int)e.Key;
            else if (textBox.Name.Equals("tb5"))
                keys[4] = (int)e.Key;
            else if (textBox.Name.Equals("tb6"))
                keys[5] = (int)e.Key;
        }
    }
}
