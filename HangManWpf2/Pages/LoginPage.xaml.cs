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

namespace WpfHangMan.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        string userName;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Onload(object sender, RoutedEventArgs e)
        {
            LogintxtBox.Focusable=true;
            LogintxtBox.Focus();
        }
        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            userName = LogintxtBox.Text;
            mainPage.UserName = userName;
            this.NavigationService.Navigate(mainPage);
        }
    }
}
