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
using Legitarsasagok_Wpf.Model;
using Legitarsasagok_WPF.Pages;

namespace Legitarsasagok_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Pages1 : Page
    {
        public Pages1()
        {
            InitializeComponent();
        }

        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Label).Name)
            {
                case "Page1": 
                    MainWindow.context.MakeVisible("Page1");
                    break;
                case "Page2":
                    MainWindow.context.MakeVisible("Page2");
                    Pages2.Instance.bt.Visibility = Visibility.Visible;
                    Pages2.Update();
                    break;
                case "Page3":
                    MainWindow.context.MakeVisible("Page3");
                    Pages2.Instance.bt.Visibility = Visibility.Hidden;
                    break;
                case "Page4":
                    MainWindow.context.MakeVisible("Page4");
                    Pages2.Instance.bt.Visibility = Visibility.Hidden;
                    break;
                case "Quit":
                    Application.Current.Shutdown();
                    break;
            }
        }
    }
}