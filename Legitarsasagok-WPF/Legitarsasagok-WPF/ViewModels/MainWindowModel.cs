using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace PushToWin.ViewModels
{
    public class MainWindowModel : INotifyPropertyChanged
    {

        #region PageVisibilityModel

        private Visibility visibility_Page1 = Visibility.Visible;
        private Visibility visibility_Page2 = Visibility.Hidden;
        private Visibility visibility_Page3 = Visibility.Hidden;
        private Visibility visibility_Page4 = Visibility.Hidden;
        public Visibility Visibility_Page1
        {
            get
            {
                return visibility_Page1;
            }
            set
            {
                visibility_Page1 = value;
                PropertyChangedHandler(nameof(visibility_Page1));
            }
        }
        public Visibility Visibility_Page2
        {
            get
            {
                return visibility_Page2;
            }
            set
            {
                visibility_Page2 = value;
                PropertyChangedHandler(nameof(visibility_Page2));
            }
        }
        public Visibility Visibility_Page3
        {
            get
            {
                return visibility_Page3;
            }
            set
            {
                visibility_Page3 = value;
                PropertyChangedHandler(nameof(visibility_Page3));
            }
        }
        public Visibility Visibility_Page4
        {
            get
            {
                return visibility_Page4;
            }
            set
            {
                visibility_Page4 = value;
                PropertyChangedHandler(nameof(visibility_Page4));
            }
        }
        public void MakeVisible(string s)
        {
            visibility_Page1 = s == "Page1" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_Page1));
            visibility_Page2 = s == "Page2" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_Page2));
            visibility_Page3 = s == "Page3" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_Page3));
            visibility_Page4 = s == "Page4" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_Page4));
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyChangedHandler([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
