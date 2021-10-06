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
using System.Windows.Shapes;
using WpfHangMan.Pages;

namespace WpfHangMan
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string topic;
        string userName;

        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(3500); //Kad ilgiau rodytų SplashScreen
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //MainFrame.NavigationService.Navigate(new MainPage());
            MainFrame.NavigationService.Navigate(new LoginPage());
        }
    }
}
