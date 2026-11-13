using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UrhajoAszt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Urhajo
    {
        public string Nev { get; set; }
        public int Legenyseg { get; set; }
        public int MaxHatotav { get; set; }
        public int UzemenyagSzint { get; set; }
        public string Gyarto { get; set; }
        public string KuldetesStatusz { get; set; }
        public int InditasEve { get; set; }
    }
    public partial class MainWindow : Window
    {
        List<Urhajo> lista = new List<Urhajo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            lista.Clear();
            lista.Add(new Urhajo { Nev = "Falcon-9", Legenyseg = 7, MaxHatotav = 550000, UzemenyagSzint = 87, Gyarto = "SpaceX", KuldetesStatusz = "Sikeres", InditasEve = 2020 });
            lista.Add(new Urhajo { Nev = "Orion-X1", Legenyseg = 4, MaxHatotav = 820000, UzemenyagSzint = 73, Gyarto = "NASA", KuldetesStatusz = "Folyamatban", InditasEve = 2023 });
            lista.Add(new Urhajo { Nev = "StarRider", Legenyseg = 12, MaxHatotav = 910000, UzemenyagSzint = 66, Gyarto = "Boeing", KuldetesStatusz = "Sikeres", InditasEve = 2019 });
            lista.Add(new Urhajo { Nev = "SolarWind", Legenyseg = 3, MaxHatotav = 300000, UzemenyagSzint = 92, Gyarto = "ESA", KuldetesStatusz = "Sikertelen", InditasEve = 2018 });
            lista.Add(new Urhajo { Nev = "Galaxy-Cruiser", Legenyseg = 18, MaxHatotav = 1200000, UzemenyagSzint = 54, Gyarto = "Blue Origin", KuldetesStatusz = "Sikeres", InditasEve = 2022 });
            lista.Add(new Urhajo { Nev = "Nova-Prime", Legenyseg = 10, MaxHatotav = 760000, UzemenyagSzint = 80, Gyarto = "Roscosmos", KuldetesStatusz = "Sikeres", InditasEve = 2017 });
            lista.Add(new Urhajo { Nev = "Pioneer-VII", Legenyseg = 6, MaxHatotav = 640000, UzemenyagSzint = 70, Gyarto = "NASA", KuldetesStatusz = "Folyamatban", InditasEve = 2024 });
            lista.Add(new Urhajo { Nev = "Titan-Hawk", Legenyseg = 14, MaxHatotav = 1050000, UzemenyagSzint = 48, Gyarto = "SpaceX", KuldetesStatusz = "Sikeres", InditasEve = 2021 });
            lista.Add(new Urhajo { Nev = "CosmoJet", Legenyseg = 5, MaxHatotav = 430000, UzemenyagSzint = 93, Gyarto = "JAXA", KuldetesStatusz = "Sikertelen", InditasEve = 2016 });
            lista.Add(new Urhajo { Nev = "Nebula-FX", Legenyseg = 11, MaxHatotav = 870000, UzemenyagSzint = 60, Gyarto = "ESA", KuldetesStatusz = "Sikeres", InditasEve = 2020 });

            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = lista;
        }

        private void btnDarab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Összesen " + lista.Count + " űrhajó van.");
        }

        private void btnHatotav_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be az adatokat!");
                return;
            }

            Urhajo legjobb = lista[0];
            foreach (Urhajo u in lista)
            {
                if (u.MaxHatotav > legjobb.MaxHatotav)
                {
                    legjobb = u;
                }
            }
            MessageBox.Show("Legnagyobb hatótáv: " + legjobb.Nev + " (" + legjobb.MaxHatotav + ")");
        }

        private void btnSikeres_Click(object sender, RoutedEventArgs e)
        {
            List<Urhajo> sikeresek = new List<Urhajo>();
            foreach (Urhajo u in lista)
            {
                if (u.KuldetesStatusz == "Sikeres")
                {
                    sikeresek.Add(u);
                }
            }

            dgUrhajok.ItemsSource = null;
            dgUrhajok.ItemsSource = sikeresek;
        }

        private void btnAtlag_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be az adatokat!");
                return;
            }

            double osszeg = 0;
            foreach (Urhajo u in lista)
            {
                osszeg += u.Legenyseg;
            }
            double atlag = osszeg / lista.Count;
            MessageBox.Show("Átlagos legénységszám: " + atlag.ToString("0.0"));
        }

        private void btnGyartok_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> gyartok = new Dictionary<string, int>();
            foreach (Urhajo u in lista)
            {
                if (gyartok.ContainsKey(u.Gyarto))
                {
                    gyartok[u.Gyarto]++;
                }
                else
                {
                    gyartok.Add(u.Gyarto, 1);
                }
            }

            string szoveg = "";
            foreach (KeyValuePair<string, int> par in gyartok)
            {
                szoveg += par.Key + ": " + par.Value + " db\n";
            }
            MessageBox.Show(szoveg, "Gyártók szerint");
        }

        private void btnKereses_Click(object sender, RoutedEventArgs e)
        {
            string keresett = txtKereses.Text.ToLower();
            string talalatok = "";

            foreach (Urhajo u in lista)
            {
                if (u.Nev.ToLower().Contains(keresett))
                {
                    talalatok += u.Nev + ", ";
                }
            }

            if (talalatok == "")
            {
                txtEredmeny.Text = "Nincs találat.";
            }
            else
            {
                txtEredmeny.Text = talalatok.TrimEnd(',', ' ');
            }
        }

    }
}