using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Runner : Page
    {


        public Runner()
        {
            this.InitializeComponent();
            StoryboardRunning.Begin();
            sbShuriken.Begin();
        }

       

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnHighScore_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Highscores));
        }
        
        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        double timesTicked = 0;
        long timesToTick = 1000000;

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0);
            //IsEnabled defaults to false 
            //tblHighscore.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
           // tblHighscore.Text += "Calling dispatcherTimer.Start()\n";
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start 
            //tblHighscore.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        }
        void dispatcherTimer_Tick(object sender, object e)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            //lastTime = time;
            //Time since last tick should be very very close to Interval 
            tblHighscore.Text =  "\t" + span.ToString();
            timesTicked++;
            if (timesTicked > timesToTick)
            {
                stopTime = time;
                tblHighscore.Text = "Calling dispatcherTimer.Stop()\n";
                dispatcherTimer.Stop();
                //IsEnabled should now be false after calling stop 
                tblHighscore.Text = "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
                span = stopTime - startTime;
                tblHighscore.Text = "Total Time Start-Stop: " + span.ToString() + "\n";
            }
        }

            private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimerSetup();

        }
    }
    
}
