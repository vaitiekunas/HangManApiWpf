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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        string topic;
        string userName;

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private void Onload(object sender, RoutedEventArgs e)
        {
            UserNametxtBlock.Text = userName;

            switch (topic)
            {
                case null:
                    RBtnActors.IsChecked = true;
                    break;

                case "Actor":
                    RBtnActors.IsChecked = true;
                    break;

                case "Film":
                    RBtnFims.IsChecked = true;
                    break;

                case "Country":
                    RBtnCountries.IsChecked = true;
                    break;

                case "LtAnimal":
                    RBtnLtAnimals.IsChecked = true;
                    break;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonBeginClick(object sender, RoutedEventArgs e)
        {
            if (RBtnActors.IsChecked == true)
            {
                topic = "Actor";
            }
            else if (RBtnFims.IsChecked == true)
            {
                topic = "Film";
            }
            else if (RBtnCountries.IsChecked == true)
            {
                topic = "Country";
            }
            else if (RBtnLtAnimals.IsChecked == true)
            {
                topic = "LtAnimal";
            }

            HangManGamePage hangManGamePage = new HangManGamePage();
            hangManGamePage.UserName = userName;
            hangManGamePage.Topic = topic;
            this.NavigationService.Navigate(hangManGamePage);
        }

        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();
        }
    }
}
