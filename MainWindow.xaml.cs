using System.IO;
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
using System.IO;

namespace vilagjarvany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Jarvanyok
        {
            public string nev { get; set; }
            public int kezdete { get; set; }
            public int vege { get; set; }
            public int ald_szama { get; set; }
            public string egyeb { get; set; }
            public Jarvanyok(string sor)
            {
                string[] t = sor.Split(';');
                nev = t[0];
                kezdete = Convert.ToInt32(t[1]);
                vege = Convert.ToInt32(t[2]);
                ald_szama = Convert.ToInt32(t[3]);
                egyeb = t[4];
            }
        }
        List<Jarvanyok> list = new List<Jarvanyok>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var i in File.ReadAllLines("vilagjarvany.txt").Skip(1))
            {
                list.Add(new Jarvanyok(i));
            }
        }

        private void adatokbe_Click(object sender, RoutedEventArgs e)
        {
            lista.Items.Clear();
            foreach (var i in list)
            {
                lista.Items.Add("Járvány neve: " +i.nev+ "Kezdési dátum: " +i.kezdete+ "Befejezési dátum: " +i.vege+ "Áldozatok száma: " +i.ald_szama+ "Egyéb adatok: " + i.egyeb);
            }
        }

        private void kereses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void statisztika_Click(object sender, RoutedEventArgs e)
        {
            lista.Items.Clear();
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var item in list)
            {
                
            }

        }

        private void szures_Click(object sender, RoutedEventArgs e)
        {
            var legtobbaldozat = list.Max(x => x.ald_szama);
            var legtobbaldozatvirusnev = list.Where(x => x.ald_szama == legtobbaldozat).Select(x => x);
            foreach (var i in legtobbaldozatvirusnev)
            {
                lista.Items.Add("Veszélyes Járvány neve: " + i.nev + "Kezdési dátum: " + i.kezdete + "Befejezési dátum: " + i.vege + "Áldozatok száma: " + i.ald_szama + "Egyéb adatok: " + i.egyeb);

            }
        }
    }
}