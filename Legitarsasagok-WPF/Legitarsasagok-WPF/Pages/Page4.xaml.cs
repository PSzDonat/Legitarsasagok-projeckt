using Legitarsasagok_Wpf.Model;
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

namespace Legitarsasagok_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Pages4 : Page
    {
        private DataBaseContext db = new DataBaseContext();
        private List<string> Varosok { get; set; }
        public Pages4()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CB1.SelectedItem == null && CB1.SelectedItem == string.Empty) return;
            if (CB2.SelectedItem == null && CB2.SelectedItem == string.Empty) return;
            MainWindow.context.MakeVisible("Page2");
            string s1 = CB1.SelectedItem.ToString();
            string s2 = CB2.SelectedItem.ToString();
            List<RepuloJaratok> datas = new List<RepuloJaratok>();
            //find kettö közötti
            List<RepuloJaratok> findall = db.RepuloJaratok.Where(x => x.Honnan == s1).Where(x => x.Hova == s2).ToList(); // megnézük hogy van e közötte repülö
            
            if (findall.Count() == 0 || !(findall[0].Tavolsag <= 600)) 
            {
                List<string> atszalasHova = db.RepuloJaratok.Where(x => x.Hova != s2 && x.Honnan == s1).Select(x=>x.Hova).Distinct().ToList(); //megnézzük az összes országot hogy hova mehet
                for (int i = 0; i < atszalasHova.Count(); i++) 
                {
                    List<RepuloJaratok> findall2 = db.RepuloJaratok.Where(x => x.Honnan == atszalasHova[i]).Where(x => x.Hova == s2).ToList(); //megnézük az országokat hogy abban az országban meg e repülö 
                    if (findall2.Count() != 0) // ha igen
                    {
                        List<RepuloJaratok> elsorszag = db.RepuloJaratok.Where(x => x.Hova == findall2[0].Honnan && x.Honnan == s1).ToList();
                        datas.Add(elsorszag[0]);
                        datas.Add(findall2[0]);

                        break;
                    }
                }
            }
            else
            {
                datas.Add(findall[0]);
            }

            Pages2.Instance.DG.ItemsSource = datas;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Varosok = db.Varosok.ToList().Select(x => x.VarosNeve).Distinct().ToList();
            CB1.ItemsSource = Varosok;
        }

        private void CB1_DropDownClosed(object sender, EventArgs e)
        {
            CB2.ItemsSource = Varosok;
            Console.WriteLine();
        }
    }
}
