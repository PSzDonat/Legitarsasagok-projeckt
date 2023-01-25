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
using Legitarsasagok_WPF.Pages;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Legitarsasagok_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Pages2 : Page
    {
        public static Pages2 Instance { get; set; }
        public Pages2()
        {
            InitializeComponent();
            Instance = this;
        }
        public static void Update()
        {
            DataBaseContext db = new DataBaseContext();
            List<RepuloJaratok> data = db.RepuloJaratok.ToList();
            Instance.DG.ItemsSource = ConvertListTime(data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<RepuloJaratok> data = new DataBaseContext().RepuloJaratok.ToList();
            DG.ItemsSource = ConvertListTime(data);

        }
        public static List<RepuloJaratokTime> ConvertListTime(List<RepuloJaratok> data)
        {
            List<RepuloJaratokTime> temp = new List<RepuloJaratokTime>();
            for (int i = 0; i < data.Count(); i++)
            {
                double calc = (double)data[i].UtazasiIdo / (double)60;
                string s = calc.ToString("#.#");
                string[] c = s.Split(",");
                string d1 = c[0] == string.Empty ? "0" : c[0];
                string d2 = c.Length !=1 ? c[1] : "0";
                string combine = $"{d1}:{d2}";
                temp.Add(new RepuloJaratokTime
                {
                    ID = data[i].ID,
                    Legitarsasag = data[i].Legitarsasag,
                    Honnan = data[i].Honnan,
                    Hova = data[i].Hova,
                    Tavolsag = data[i].Tavolsag,
                    UtazasiIdo = combine,
                    UtazasiDij = data[i].UtazasiDij
                });
                
            }
            return temp;
        }
    }
}
