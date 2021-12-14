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
using System.Windows.Shapes;

namespace listaosob3a
{
    /// <summary>
    /// Logika interakcji dla klasy WindowOsoba.xaml
    /// </summary>
    public partial class WindowOsoba : Window
    {
        public WindowOsoba(Osoba osoba)
        {
            InitializeComponent();
            DataContext = osoba;
        }

        private void zapisz_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
