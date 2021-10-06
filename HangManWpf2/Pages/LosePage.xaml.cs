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
    /// Interaction logic for LosePage.xaml
    /// </summary>
    public partial class LosePage : Page
    {
        string userName;
        string topic;
        string rightWord;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public string RightWord
        {
            get { return rightWord; }
            set { rightWord = value; }
        }


        public LosePage()
        {
            InitializeComponent();
        }

        private void Onload(object sender, RoutedEventArgs e)
        {
            UserNametxtBlock.Text = userName;
            RightWordtxtBlock.Text = rightWord;
        }

        private void OnMainPageButtonClick(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.UserName = userName;
            mainPage.Topic = topic;
            this.NavigationService.Navigate(mainPage);
        }

        private void OnNewWordButtonClick(object sender, RoutedEventArgs e)
        {
            HangManGamePage hangManGamePage = new HangManGamePage();
            hangManGamePage.UserName = userName;
            hangManGamePage.Topic = topic;
            this.NavigationService.Navigate(hangManGamePage);
        }
    }
}
