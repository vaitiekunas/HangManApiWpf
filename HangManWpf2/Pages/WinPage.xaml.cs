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
    /// Interaction logic for WinPage.xaml
    /// </summary>
    public partial class WinPage : Page
    {
        string topic;
        string rightWord;
        string timeResult;
        string userName;
        int recordBest;
        int points;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int BestRecord
        {
            get { return recordBest; }
            set { recordBest = value; }
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public string TimeResult
        {
            get { return timeResult; }
            set { timeResult = value; }
        }

        public int PointsResult
        {
            get { return points; }
            set { points = value; }
        }

        public int BestResult
        {
            get { return recordBest; }
            set { recordBest = value; }
        }

        public string RightWord
        {
            get { return rightWord; }
            set { rightWord = value; }
        }

        public WinPage()
        {
            InitializeComponent();
        }

        private void Onload(object sender, RoutedEventArgs e)
        {
            UserNametxtBlock.Text = userName;
            RightWordtxtBlock.Text = rightWord;
            TimeResulttxtBlock.Text = timeResult;
            PointsLabel.Content = points;
            BestPointsLabel.Content = recordBest;
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
