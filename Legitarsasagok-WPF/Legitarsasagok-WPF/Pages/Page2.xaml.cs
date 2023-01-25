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
            Instance.DG.ItemsSource = db.RepuloJaratok.ToList();
        }
    }
}
