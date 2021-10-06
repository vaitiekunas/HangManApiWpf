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
using System.Net.Http;
using System.Net.Http.Json;
using WpfHangMan.Pages;
using System.Diagnostics;
using System.Timers;

namespace WpfHangMan
{
    /// <summary>
    /// Interaction logic for HangManGamePage.xaml
    /// </summary>
    public partial class HangManGamePage : Page
    {
        private Stopwatch _stopwatch;
        private Timer _timer;
        private const string _startTimeDisplay = "00:00:00";
        List<char> pressed = new List<char>();
        string userName;
        string topic;
        string word;
        string wordUpper;
        char[] chars;
        int triesLeft;
        string timeResult;
        double pointsTemp;
        int points;
        int recordBest;

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
        
        private HttpClient _client = new HttpClient();

        private async void Onload(object sender, RoutedEventArgs e)
        {
            triesLeft = 11;
            TriesLeftCountLabel.Content = Convert.ToString(triesLeft);
            WordBlock.Text = "";
            pressed.Clear();

            var tempUrl = $"http://localhost:25901/words/{topic}";
            var url = tempUrl;
            var response = await _client.GetFromJsonAsync<List<string>>(url);

            Random random = new Random();
            int i = random.Next(response.Count);
            word = response[i];
            wordUpper = word.ToUpper();
            chars = wordUpper.ToCharArray();

            var grUrl = $"http://localhost:25901/records/ReadRecord";
            var responseRec = await _client.GetFromJsonAsync<List<int>>(grUrl);

            recordBest = responseRec[0];

            NewWordBlock.Text = word; //********************sufleris********************

            foreach (char ch in chars)
            {
                if (pressed.Contains(ch) || !Char.IsLetter(ch))
                {
                    WordBlock.Text += Convert.ToString(ch);
                }
                else
                {
                    WordBlock.Text += "?";
                }
            }

            _stopwatch.Start();
            _timer.Start();
        }
        
        private void OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => TimerCountLabel.Content = _stopwatch.Elapsed.ToString(format: @"hh\:mm\:ss"));
        }
        public HangManGamePage()
        {
            InitializeComponent();

            TimerCountLabel.Content = _startTimeDisplay;
            _stopwatch = new Stopwatch();
            _timer = new Timer(interval: 1000);
            _timer.Elapsed += OnTimerElapse;
        }

        private void OnLetterButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string pressedKey = button.Name.ToString();
            string key = pressedKey.Substring(pressedKey.Length - 1);

            if (!pressed.Contains(char.Parse(key)))
            {
                pressed.Add(char.Parse(key));

                if (!wordUpper.Contains(key))
                {
                    button.Background = Brushes.LightCoral;
                    triesLeft--;
                    TriesLeftCountLabel.Content = Convert.ToString(triesLeft);

                    switch (triesLeft)
                    {
                        case 0:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h0t.png"));
                            break;

                        case 1:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h1t.png"));
                            break;

                        case 2:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h2t.png"));
                            break;

                        case 3:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h3t.png"));
                            break;

                        case 4:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h4t.png"));
                            break;

                        case 5:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h5t.png"));
                            break;

                        case 6:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h6t.png"));
                            break;

                        case 7:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h7t.png"));
                            break;

                        case 8:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h8t.png"));
                            break;

                        case 9:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h9t.png"));
                            break;

                        case 10:
                            HangImg.Source = new BitmapImage(new Uri("D:/Desktop/Programavimo kursai/WpfHangMan/WpfHangMan/img/h10t.png"));
                            break;

                        case 11:
                            HangImg.Source = new BitmapImage(null);
                            break;
                    }

                    if (triesLeft < 4)
                    {
                        TriesLeftCountLabel.Foreground = Brushes.Red;
                    }

                    if (triesLeft == 0)
                    {
                        _stopwatch.Stop();
                        _timer.Stop();
                        
                        System.Threading.Thread.Sleep(3500);

                        LosePage losePage = new LosePage();
                        losePage.UserName = userName;
                        losePage.RightWord = wordUpper;
                        losePage.Topic = topic;
                        this.NavigationService.Navigate(losePage);
                    }
                }
                else
                {
                    button.Background = Brushes.SeaGreen;
                    WordBlock.Text = "";

                    foreach (char ch in chars)
                    {
                        if (pressed.Contains(ch) || !Char.IsLetter(ch))
                        {
                            WordBlock.Text += Convert.ToString(ch);
                        }
                        else
                        {
                            WordBlock.Text += "?";
                        }
                    }

                    if (!WordBlock.Text.Contains("?"))
                    {
                        _stopwatch.Stop();
                        _timer.Stop();
                        pointsTemp = (double)((pressed.Count-(11-triesLeft))/(double)triesLeft)*1000;
                        points = Convert.ToInt32(pointsTemp);

                        WinPage winPage = new WinPage();
                        winPage.UserName = userName;
                        winPage.RightWord = wordUpper;
                        winPage.Topic = topic;
                        winPage.PointsResult = points;
                        winPage.BestRecord = recordBest;
                        timeResult = _stopwatch.Elapsed.ToString(format: @"hh\:mm\:ss");
                        winPage.TimeResult = timeResult;
                        this.NavigationService.Navigate(winPage);

                        var recUrl = $"http://localhost:25901/records/AddRecord";

                        var record = new {
                            userName = userName,
                            userPoints = points};
                        var response = _client.PostAsJsonAsync(recUrl, record);
                    }
                }
            }
        }

        private void OnMainPageButtonClick(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();
            _timer.Stop();
            MainPage mainPage = new MainPage();
            mainPage.UserName = userName;
            mainPage.Topic = topic;
            this.NavigationService.Navigate(mainPage);
        }

        private void OnNewWordButtonClick(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();
            _timer.Stop();
            HangManGamePage hangManGamePage = new HangManGamePage();
            hangManGamePage.UserName = userName;
            hangManGamePage.Topic = topic;
            this.NavigationService.Navigate(hangManGamePage);
        }
    }
}
