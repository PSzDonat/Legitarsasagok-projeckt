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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Pages3 : Page
    {
        private DataBaseContext db = new DataBaseContext();
        private List<string> Varosok { get; set; }
        public Pages3()
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
            List<RepuloJaratok> find = db.RepuloJaratok.Where(x => x.Honnan == s1).Where(x => x.Hova == s2).ToList();
            Pages2.Instance.DG.ItemsSource = find;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {  
            Varosok = db.Varosok.ToList().Select(x => x.VarosNeve).Distinct().ToList();
            CB1.ItemsSource = Varosok;
        }

        private void CB1_DropDownClosed(object sender, EventArgs e)
        {
            List<string> temp = db.RepuloJaratok.Where(x => x.Honnan == CB1.SelectedItem).Select(x=>x.Hova).Distinct().ToList();
            CB2.ItemsSource = temp;
            Console.WriteLine();
        }
    }
}
