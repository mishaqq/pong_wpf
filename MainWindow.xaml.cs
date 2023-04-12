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
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics.Metrics;

namespace BallSpiel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        private readonly DispatcherTimer _animationsTimer = new DispatcherTimer();
        bool gehtNachRechts = true;
        bool gehtNachUnten = true;
        int red_score = 0, green_score  = 0 ;
        public MainWindow()
        {
            InitializeComponent();

            _animationsTimer.Interval = TimeSpan.FromMilliseconds(0.1);
            _animationsTimer.Tick += NeuPositionBall;

            
        }
        private void RedPlayer(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.W)
                {
                    Canvas.SetTop(Red, Canvas.GetTop(Red) - 100);
                }

                if (e.Key == Key.S)
                {
                    Canvas.SetTop(Red, Canvas.GetTop(Red) + 100);
                }
            
           /* if (e.Key == Key.A)
            {
                Canvas.SetLeft(Hunter, Canvas.GetLeft(Hunter) - 10);
            }
            if (e.Key == Key.D)
            {
                Canvas.SetLeft(Hunter, Canvas.GetLeft(Hunter) + 10);
            }
           */
        }

        private void GreenPlayer(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Up)
                {
                    Canvas.SetTop(Green, Canvas.GetTop(Green) - 100);
                }

                if (e.Key == Key.Down)
                {
                    Canvas.SetTop(Green, Canvas.GetTop(Green) + 100);
                }

            
            /* if (e.Key == Key.A)
             {
                 Canvas.SetLeft(Hunter, Canvas.GetLeft(Hunter) - 10);
             }
             if (e.Key == Key.D)
             {
                 Canvas.SetLeft(Hunter, Canvas.GetLeft(Hunter) + 10);
             }
            */
        }

        private void NeuPositionBall(object? sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);


            if (gehtNachRechts)
            {
                Canvas.SetLeft(Ball, x + 0.08);
             
            }
            else
            {
               
                Canvas.SetLeft(Ball, x - 0.08);
            }
            if(x >= SpielPlatz.ActualWidth - Ball.Width)
            {

                red_score += 1;
                Clicks_Red_counter.Content = red_score;
                Canvas.SetLeft(Ball, 437);
                Canvas.SetTop(Ball, 330);
                gehtNachRechts = false;


            }

            if (x <= 0 )
            {
                green_score += 1;
                Clicks_Green_counter.Content = green_score;
                Canvas.SetLeft(Ball, 437);
                Canvas.SetTop(Ball, 330);
                gehtNachRechts = true;
            }

            if ( x >= (Canvas.GetLeft(Green) - 35) && (y > Canvas.GetTop(Green) - 63 && y < Canvas.GetTop(Green) + 69))
            {
                gehtNachRechts=false;
               
            }

            if ( x <= (Canvas.GetLeft(Red) + 15) && (y > Canvas.GetTop(Red) - 63 && y < Canvas.GetTop(Red) + 63))
            {
                gehtNachRechts =true;
            }


            if (gehtNachUnten)
            {
                Canvas.SetTop(Ball, y + 0.08);

            }
            else
            {

                Canvas.SetTop(Ball, y - 0.08);
            }

            if (y >= SpielPlatz.ActualHeight - Ball.Width)
            {
                gehtNachUnten = false;
            }

            if (y <= 0)
            {
                gehtNachUnten = true;
            }

           

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
               
                _animationsTimer.Stop();
            }
            else
            {
               
                _animationsTimer.Start();
            }

            red_score = 0;
            green_score = 0;
            Clicks_Green_counter.Content = green_score;
            Clicks_Red_counter.Content = red_score;

            var mitteX = SpielPlatz.ActualWidth / 2;
           var mitteY = SpielPlatz.ActualHeight / 2;

            Canvas.SetLeft(Ball, mitteX);
            Canvas.SetTop(Ball, mitteY);
        }
    }
}
