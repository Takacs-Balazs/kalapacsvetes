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

namespace kalapacsvet
{

    public partial class MainWindow : Window
    {
        ObservableCollection<Versenyzo> versenyzok = Versenyzo.Beolvasas("Selejtezo2012.txt");
        public MainWindow()
        {
            InitializeComponent();
            athleteComboBox.ItemsSource = versenyzok.Select(x => x.Nev);
            athleteComboBox.SelectedItem = "Pars Krisztián";
        }

        private void athleteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var kivalasztott = versenyzok[athleteComboBox.SelectedIndex];
            lbOrszag.Content = kivalasztott.CsakNemzet;
            lbNemzet.Content = kivalasztott.Kód;
            lbEredmeny.Content = kivalasztott.Eredmény();
            lbOrder.Content = $"{kivalasztott.D1};{kivalasztott.D2};{kivalasztott.D3}";
            lbCsoport.Content = kivalasztott.Csoport;

            imgKep.Source = new BitmapImage(new Uri("img/" + kivalasztott.Kód + ".png", UriKind.Relative));

        }
    }
}
