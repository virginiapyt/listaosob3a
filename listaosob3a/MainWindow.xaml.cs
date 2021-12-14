using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;

namespace listaosob3a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public ObservableCollection<Osoba> Listaosob { get; set; }
        public Osoba wybranaOsoba { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Przygotujwiazanie();

        }

        private void Przygotujwiazanie()
        {
           Listaosob = new ObservableCollection<Osoba>();
            Listaosob.Add(new Osoba("Ala", "Kowalska", new DateTime(2004, 12, 6)));
            Listaosob.Add(new Osoba("Ola", "Nowak", new DateTime(2005, 12, 2)));
            Listaosob.Add(new Osoba("Ela", "Abacka", new DateTime(2004, 12, 6)));
            Listaosob.Add(new Osoba("Ala", "Abacka", new DateTime(2004, 12, 6)));
            Listaosob.Add(new Osoba("Ula", "Abacka", new DateTime(2004, 12, 6)));
            Listaosob.Add(new Osoba("Beata", "Kowalska", new DateTime(2004, 12, 6)));
            DataContext = this;

            CollectionView widok =
                (CollectionView)CollectionViewSource.GetDefaultView(Listaosob);
            widok.SortDescriptions.
                Add(new SortDescription("Nazwisko", ListSortDirection.Ascending));
            widok.SortDescriptions.
                Add(new SortDescription("Imie", ListSortDirection.Ascending));

            widok.Filter = mojfiltr;

        }

        private bool mojfiltr(object obj)
        {
            if (String.IsNullOrEmpty(txtSzukaj.Text))
            {
                return true;
            }
            else
                return ((obj as Osoba).Nazwisko.IndexOf(txtSzukaj.Text,
                    StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtSzukaj_TextChanged(object sender, 
            TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Listaosob).Refresh();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = new Osoba("", "", new DateTime(2022,1,1));
            Window window = new WindowOsoba(osoba);
            var result = window.ShowDialog();
            if (result == true)
            {
                Listaosob.Add(osoba);
            }
        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {
            if (wybranaOsoba == null) return;
            Osoba kopia =(Osoba) wybranaOsoba.Clone();
            Window window = new WindowOsoba(kopia);
            var result = window.ShowDialog();
            if (result == true)
            {
                Listaosob.Remove(wybranaOsoba);
                Listaosob.Add(kopia);
            }

        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            if (wybranaOsoba == null) return;
            var result = MessageBox.Show("Czy chcesz skasować",
                "Potwierdzenie",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                   Listaosob.Remove(wybranaOsoba);
        }
    }
}
